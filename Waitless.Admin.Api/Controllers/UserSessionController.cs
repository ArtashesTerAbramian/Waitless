using Ardalis.Result;
using Waitless.BLL.Services.UserService;
using Waitless.DTO;
using Waitless.DTO.UsersDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Waitless.Admin.Api.Controllers;

public class UserSessionController : ApiControllerBase
{
    private readonly IUserSessionService _userSessionService;

    public UserSessionController(IUserSessionService userSessionService)
    {
        _userSessionService = userSessionService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<Result<UserSessionDto>> Add(LoginDto dto)
    {
        return await _userSessionService.Add(dto);
    }

    [Authorize]
    [HttpPost("log-out")]
    public async Task<Result<bool>> Delete()
    {
        return await _userSessionService.Delete();
    }

    [Authorize]
    [HttpPost("get-user-info")]
    public async Task<Result<UserDto>> GetUserCurrentInfo()
    {
        return await Task.FromResult(_userSessionService.GetUserCurrentInfo());
    }   
    
}