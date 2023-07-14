using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Services.UserService;
using Waitless.Dto;
using Waitless.DTO.UsersDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Waitless.Api.Controllers;

public class UserController : ApiControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("get-all")]
    public async Task<PagedResult<List<UserDto>>> GetAll([FromQuery] UserFilter filter)
    {
        return await _userService.GetAllAsync(filter);
    }

    [HttpGet("get-by-id")]
    public async Task<Result<UserDto>> Get(long id)
    {
        return await _userService.GetByIdAsync(id);
    }

    [HttpGet("get-by-username")]
    public async Task<Result<UserDto>> GetByUsernameAsync(string username)
    {
        return await _userService.GetUserByUsernameAsync(username);
    }

    [AllowAnonymous]
    [HttpPost("add")]
    [DisableRequestSizeLimit]
    public async Task<Result> Add(AddUserDto dto)
    {
        return await _userService.AddUserAsync(dto);
    }

    [HttpPost("update")]
    [DisableRequestSizeLimit]
    public async Task<Result> Update(UpdateUserDto dto)
    {
        return await _userService.UpdateAsync(dto);
    }

    [HttpPost("delete")]
    public async Task<Result> Delete(BaseDto dto)
    {
        return await _userService.Delete(dto.Id);
    }
}