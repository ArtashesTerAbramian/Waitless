using Ardalis.Result;
using Waitless.BLL.Helpers;
using Waitless.BLL.Mappers;
using Waitless.BLL.Models;
using Waitless.DAL;
using Waitless.DAL.Models;
using Waitless.DTO;
using Waitless.DTO.UsersDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace Waitless.BLL.Services.UserService;

public class UserSessionService : IUserSessionService
{
    private readonly AppDbContext _db;
    private readonly IHttpContextAccessor _httpContext;
    private readonly PasswordHashHelper _passwordHashHelper;
    private readonly AuthOptions _options;

    public UserSessionService(AppDbContext db,
        IOptions<AuthOptions> options,
        IHttpContextAccessor httpContext,
        PasswordHashHelper passwordHashHelper)
    {
        _db = db;
        _httpContext = httpContext;
        _passwordHashHelper = passwordHashHelper;
        _options = options.Value;
    }
    
    public async Task<Result<UserSessionDto>> Add(LoginDto dto)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(x => x.UserName == dto.UserName.ToLower());


        if (user == null || !_passwordHashHelper.VerifyPassword(dto.Password, user.PasswordHash))
        {
            return Result.Error("Incorect entered data");
        }
        
        var token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
        
        var session = new UserSession()
        {
            UserId = user.Id,
            Token = token,
            IsExpired = false,
        };

        _db.UserSessions.Add(session);

        await _db.SaveChangesAsync();

        var response = session.MapToUserSessionDto();

        return response;
    }

    public async Task<Result<bool>> Delete()
    {
        _httpContext.HttpContext.Request.Headers.TryGetValue(HeaderNames.Authorization, out var token);

        var session = await _db.UserSessions.FirstOrDefaultAsync(x => x.Token == token.ToString());

        if (session != null)
        {
            session.IsExpired = true;
            session.IsDeleted = true;

            await _db.SaveChangesAsync();
        }

        return true;
    }

    public async Task<User> GetByToken(string token)
    {
        var userSession = await _db.UserSessions
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Token == token && !x.IsExpired
                                                       && x.User.IsDeleted != true);

        if (userSession == null)
        {
            return null;
        }
        
        if (userSession.ModifyDate.Value.AddMinutes(_options.TokenExpirationTimeInMinutes) < DateTime.Now)
        {
            userSession.IsExpired = true;

            await _db.SaveChangesAsync();

            return null;
        }
        
        userSession.ModifyDate = DateTime.Now;

        await _db.SaveChangesAsync();

        return userSession.User;
    }

    public Result<UserDto> GetUserCurrentInfo()
    {
        throw new NotImplementedException();
    }
}