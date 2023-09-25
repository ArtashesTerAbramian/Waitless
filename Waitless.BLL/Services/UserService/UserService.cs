using Ardalis.Result;
using Waitless.BLL.Filters;
using CryptoHelper;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DAL.Models;
using Waitless.DTO.UsersDtos;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Waitless.BLL.Services.MailService;
using Waitless.DAL.Enums;
using Waitless.BLL.Models;
using Waitless.BLL.Constants;
using Waitless.DTO;
using Microsoft.Extensions.Options;
using Waitless.BLL.Services.ErrorService;

namespace Waitless.BLL.Services.UserService;

public class UserService : IUserService
{
    private readonly AppDbContext _db;
    private readonly SiteUrlInfo _siteUrlInfo;
    private readonly IMailService _mailService;
    private readonly IErrorService _errorService;

    public UserService(AppDbContext db,
        IOptions<SiteUrlInfo> siteUrlInfo,
        IMailService mailService,
        IErrorService errorService)
    {
        _db = db;
        _siteUrlInfo = siteUrlInfo.Value;
        _mailService = mailService;
        _errorService = errorService;
    }

    public async Task<Result> AddUserAsync(AddUserDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        if (_db.Users.Any(x => x.UserName == dto.UserName.ToLower()))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.UserNameAlreadyTaken).Result.Description;
            return Result.Error(errorMessage);
        }

        if (_db.Users.Any(x => x.Email == dto.Email))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.EmailInUse).Result.Description;
            return Result.Error(errorMessage);
        }

        if (_db.Users.Any(x => x.Phone == dto.Phone))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.UserAlreadyExistsPhone).Result.Description;
            return Result.Error(errorMessage);
        }

        var user = new User()
        {
            Email = dto.Email,
            UserName = dto.UserName.ToLower(),
            Phone = dto.Phone,
            PasswordHash = Crypto.HashPassword(dto.Password),
            ActivationToken = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N"),
        };

        await _db.Users.AddAsync(user);

        await _db.SaveChangesAsync();

        await SendRegisterEmailAsync(user, user.ActivationToken);

        scope.Complete();

        return Result.Success();
    }

    private async Task<bool> SendRegisterEmailAsync(User user, string activationToken)
    {
        string verificationLink = $"{_siteUrlInfo.WebSiteUrl}user/verify/?token={activationToken}";

        var mailTemplate = await _db.MailTemplates.FirstOrDefaultAsync(x => x.Id == (int)MailTemplateEnum.Verify);

        string message = mailTemplate.HtmlBody = mailTemplate.HtmlBody
            .Replace("{FirstName}", user.UserName)
            .Replace("{verificationLink}", verificationLink);

        return await _mailService.SendEmailAsync(user.Email, mailTemplate.Subject, message);
    }

    public async Task<PagedResult<List<UserDto>>> GetAllAsync(UserFilter filter)
    {
        var query = _db.Users;

        var users = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<UserDto>>(await filter.GetPagedInfoAsync(query), users.MapToUsersDtos());
    }

    public async Task<Result<UserDto>> GetUserByUsernameAsync(string username)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == username.ToLower());

        if (user is null)
        {
            return Result.NotFound();
        }

        return user.MapToUserDto();
    }

    public async Task<Result> UpdateAsync(UpdateUserDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (user is null)
        {
            return Result.NotFound();
        }

        if (_db.Users.Any(x => x.UserName == dto.UserName.ToLower()))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.UserNameAlreadyTaken).Result.Description;
            return Result.Error(errorMessage);
        }

        if (_db.Users.Any(x => x.Email == dto.Email))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.EmailInUse).Result.Description;
            return Result.Error(errorMessage);
        }

        if (_db.Users.Any(x => x.Phone == dto.Phone))
        {
            var errorMessage = _errorService.GetById(ErrorConstants.UserAlreadyExistsPhone).Result.Description;
            return Result.Error(errorMessage);
        }

        user.Email = dto.Email;
        user.Phone = dto.Phone;
        user.UserName = dto.UserName;

        await _db.SaveChangesAsync();

        scope.Complete();

        return Result.Success();
    }

    public async Task<Result> Delete(long id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user is null)
        {
            return Result.NotFound();
        }

        user.IsDeleted = true;

        await _db.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<bool>> VerifyUserAsync(string token)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(x => x.ActivationToken == token);

        if (user is null)
        {
            return Result.NotFound();
        }

        user.IsActive = true;
        user.ActivationToken = default;

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Result<UserDto>> GetByTokenAsync(string token)
    {
        var user = await _db.Users
            .Include(x => x.UserSessions)
            .FirstOrDefaultAsync(u => u.UserSessions.Any(s => s.Token == token));

        if (user is null)
        {
            return Result.NotFound();
        }

        return Result.Success(user.MapToUserDto());
    }

    public async Task<Result<bool>> ResetPassword(PasswordResetDto dto)
    {
        var passReset = await _db.UserPasswordResets
            .FirstOrDefaultAsync(x => x.Token.Trim() == dto.Token.Trim());

        TimeSpan elapsed = DateTime.UtcNow - passReset.CreatedDate;

        if (passReset is null || elapsed.Hours >= 24)
        {
            return Result.NotFound();
        }

        var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == passReset.UserId);

        user.PasswordHash = Crypto.HashPassword(dto.Password);

        passReset.Expired = true;
        passReset.Token = default;

        await _db.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<bool>> ResetPasswordRequest(string email)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(x => x.Email.Trim() == email.Trim()
                                      && x.IsActive);

        if (user is null)
        {
            return Result.NotFound();
        }

        var passReset = new UserPasswordReset()
        {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N"),
            Expired = false
        };

        _db.UserPasswordResets.Add(passReset);
        await _db.SaveChangesAsync();

        string resetLink = $"{_siteUrlInfo.WebSiteUrl}account/reset/?token={passReset.Token}";

        var mailTemplate = await _db.MailTemplates.FirstOrDefaultAsync(x => x.Id == (int)MailTemplateEnum.Reset);

        var message = mailTemplate.HtmlBody
            .Replace("{FirstName}", user.UserName)
            .Replace("{resetLink}", resetLink);

        await _mailService.SendEmailAsync(user.Email, mailTemplate.Subject, message);

        return Result.Success();
    }
}