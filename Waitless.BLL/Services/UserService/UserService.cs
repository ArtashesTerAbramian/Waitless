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

namespace Waitless.BLL.Services.UserService;

public class UserService: IUserService
{
    private readonly AppDbContext _db;
    private readonly IMailService _mailService;

    public UserService(AppDbContext db,
        IMailService mailService)
    {
        _db = db;
        _mailService = mailService;
    }
    
    public async Task<Result> AddUserAsync(AddUserDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        if (_db.Users.Any(x => x.UserName == dto.UserName.ToLower()))
        {
            return Result.Error("User with provided username already exists");
        }
        
        if (_db.Users.Any(x => x.Email == dto.Email))
        {
            return Result.Error("User with provided Email already exists");
        }
        
        if (_db.Users.Any(x => x.Phone == dto.Phone))
        {
            return Result.Error("User with provided phone number already exists");
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

        await SendRegisterEmail(user, user.ActivationToken);

        scope.Complete();

        return Result.Success();
    }

    private async Task<bool> SendRegisterEmail(User user, string activationToken)
    {
        string verificationLink = $"http://localhost:5254/api/user/verify/?token={activationToken}";

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

        if(user is null)
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
            return Result.Error("User with provided username already exists");
        }
        
        if (_db.Users.Any(x => x.Email == dto.Email))
        {
            return Result.Error("User with provided Email already exists");
        }
        
        if (_db.Users.Any(x => x.Phone == dto.Phone))
        {
            return Result.Error("User with provided phone number already exists");
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

        if(user is null)
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
}