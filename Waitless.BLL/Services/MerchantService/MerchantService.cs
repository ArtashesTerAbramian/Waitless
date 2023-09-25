using System.Transactions;
using Ardalis.Result;
using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Waitless.BLL.Constants;
using Waitless.BLL.Mappers;
using Waitless.BLL.Models;
using Waitless.DAL;
using Waitless.DAL.Models;
using Waitless.DTO.MerchantDtos;
using Waitless.DTO;
using Waitless.BLL.Services.ErrorService;
using Waitless.BLL.Services.MailService;
using Waitless.DAL.Enums;

namespace Waitless.BLL.Services.MerchantService;

public class MerchantService : IMerchantService
{
    private readonly AppDbContext _db;
    private readonly IErrorService _errorService;
    private readonly IMailService _mailService;
    private readonly SiteUrlInfo _siteUrlInfo;

    public MerchantService(AppDbContext db,
        IErrorService errorService,
        IOptions<SiteUrlInfo> siteUrlInfo,
        IMailService mailService)
    {
        _db = db;
        _errorService = errorService;
        _mailService = mailService;
        _siteUrlInfo = siteUrlInfo.Value;
    }

    public async Task<Result> AddMerchantAsync(AddMerchantDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        if (_db.Merchants.Any(x => x.UserName == dto.UserName.ToLower()))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.UserNameAlreadyTaken).Result.Description;
            return Result.Error(errorMessage);
        }

        if (_db.Merchants.Any(x => x.Email == dto.Email))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.EmailInUse).Result.Description;
            return Result.Error(errorMessage);
        }

        if (_db.Merchants.Any(x => x.Phone == dto.Phone))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.UserAlreadyExistsPhone).Result.Description;
            return Result.Error(errorMessage);
        }

        var merchant = new Merchant()
        {
            Email = dto.Email,
            UserName = dto.UserName.ToLower(),
            Phone = dto.Phone,
            PasswordHash = Crypto.HashPassword(dto.Password),
            ActivationToken = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N"),
        };

        await _db.Merchants.AddAsync(merchant);

        await _db.SaveChangesAsync();

        await SendRegisterEmailAsync(merchant, merchant.ActivationToken);

        scope.Complete();

        return Result.Success();
    }
    
    public async Task<Result<MerchantDto>> GetByTokenAsync(string token)
    {
        var merchant = await _db.Merchants
            .Include(x => x.MerchantSessions)
            .FirstOrDefaultAsync(u => u.MerchantSessions.Any(s => s.Token == token));

        if (merchant is null)
        {
            return Result.NotFound();
        }

        return Result.Success(merchant.MapToMerchantDto());
    }

    public async Task<Result<MerchantDto>> GetMerchantByUsernameAsync(string username)
    {
        var merchant = await _db.Merchants.FirstOrDefaultAsync(x => x.UserName.ToLower() == username);

        if (merchant is null)
        {
            return Result.NotFound();
        }

        return Result.Success(merchant.MapToMerchantDto());
    }

    public async Task<Result<bool>> VerifyMerchantAsync(string token)
    {
        var merchant = await _db.Merchants
            .FirstOrDefaultAsync(x => x.ActivationToken == token);

        if (merchant is null)
        {
            return Result.NotFound();
        }

        merchant.IsActive = true;
        merchant.ActivationToken = default;

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Result> UpdateAsync(UpdateMerchantDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var merchant = await _db.Merchants.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (merchant is null)
        {
            return Result.NotFound();
        }

        if (_db.Merchants.Any(x => x.UserName == dto.UserName.ToLower()))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.UserNameAlreadyTaken).Result.Description;
            return Result.Error(errorMessage);
        }

        if (_db.Merchants.Any(x => x.Email == dto.Email))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.EmailInUse).Result.Description;
            return Result.Error(errorMessage);
        }

        if (_db.Merchants.Any(x => x.Phone == dto.Phone))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.UserAlreadyExistsPhone).Result.Description;
            return Result.Error(errorMessage);
        }

        merchant.Email = dto.Email;
        merchant.Phone = dto.Phone;
        merchant.UserName = dto.UserName;

        await _db.SaveChangesAsync();

        scope.Complete();

        return Result.Success();
    }

    public async Task<Result> Delete(long id)
    {
        var merchant = await _db.Merchants.FirstOrDefaultAsync(x => x.Id == id);

        if (merchant is null)
        {
            return Result.NotFound();
        }

        merchant.IsDeleted = true;

        return Result.Success();
    }

    public async Task<Result<bool>> ResetPasswordRequest(string email)
    {
        var merchant = await _db.Merchants
            .FirstOrDefaultAsync(x => x.Email.Trim() == email.Trim()
                                      && x.IsActive);

        if (merchant is null)
        {
            return Result.NotFound();
        }

        var passReset = new MerchantPasswordReset()
        {
            MerchantId = merchant.Id,
            Token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N"),
            Expired = false
        };

        _db.MerchantPasswordResets.Add(passReset);
        await _db.SaveChangesAsync();

        string resetLink = $"{_siteUrlInfo.WebSiteUrl}account/reset/?token={passReset.Token}";

        var mailTemplate = await _db.MailTemplates.FirstOrDefaultAsync(x => x.Id == (int)MailTemplateEnum.Reset);

        var message = mailTemplate.HtmlBody
            .Replace("{FirstName}", merchant.UserName)
            .Replace("{resetLink}", resetLink);

        await _mailService.SendEmailAsync(merchant.Email, mailTemplate.Subject, message);

        return Result.Success();
    }

    public async Task<Result<bool>> ResetPassword(PasswordResetDto dto)
    {
        var passReset = await _db.MerchantPasswordResets
            .FirstOrDefaultAsync(x => x.Token.Trim() == dto.Token.Trim());

        TimeSpan elapsed = DateTime.UtcNow - passReset.CreatedDate;

        if (passReset is null || elapsed.Hours >= 24)
        {
            return Result.NotFound();
        }

        var user = await _db.Merchants.FirstOrDefaultAsync(x => x.Id == passReset.MerchantId);

        user.PasswordHash = Crypto.HashPassword(dto.Password);

        passReset.Expired = true;
        passReset.Token = default;

        await _db.SaveChangesAsync();

        return Result.Success();
    }
    
    private async Task<bool> SendRegisterEmailAsync(Merchant merchant, string activationToken)
    {
        string verificationLink = $"{_siteUrlInfo.WebSiteUrl}merchant/verify/?token={activationToken}";

        var mailTemplate = await _db.MailTemplates.FirstOrDefaultAsync(x => x.Id == (int)MailTemplateEnum.Verify);

        string message = mailTemplate.HtmlBody = mailTemplate.HtmlBody
            .Replace("{FirstName}", merchant.UserName)
            .Replace("{verificationLink}", verificationLink);

        return await _mailService.SendEmailAsync(merchant.Email, mailTemplate.Subject, message);
    }
}