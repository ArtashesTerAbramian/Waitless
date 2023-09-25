using Ardalis.Result;
using Waitless.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Waitless.BLL.Services.MerchantService;
using Waitless.DTO.MerchantDtos;
using Waitless.DTO;

namespace Waitless.Merchant.Api.Controllers;

public class MerchantController : ApiControllerBase
{
    private readonly IMerchantService _merchantService;

    public MerchantController(IMerchantService merchantService)
    {
        _merchantService = merchantService;
    }
    
    /*[HttpGet("get-all")]
    public async Task<PagedResult<List<UserDto>>> GetAll([FromQuery] UserFilter filter)
    {
        return await _userService.GetAllAsync(filter);
    }*/

    [HttpGet("me")]
    public async Task<Result<MerchantDto>> Get(string token)
    {
        return await _merchantService.GetByTokenAsync(token);
    }

    [HttpGet("get-by-username")]
    public async Task<Result<MerchantDto>> GetByUsernameAsync(string username)
    {
        return await _merchantService.GetMerchantByUsernameAsync(username);
    }

    [AllowAnonymous]
    [HttpPost("add")]
    [DisableRequestSizeLimit]
    public async Task<Result> Add(AddMerchantDto dto)
    {
        return await _merchantService.AddMerchantAsync(dto);
    }

    [AllowAnonymous]
    [HttpPost("verify")]
    public async Task<Result<bool>> Verify(string token)
    {
        return await _merchantService.VerifyMerchantAsync(token);
    }

    [HttpPost("update")]
    [DisableRequestSizeLimit]
    public async Task<Result> Update(UpdateMerchantDto dto)
    {
        return await _merchantService.UpdateAsync(dto);
    }

    [HttpPost("delete")]
    public async Task<Result> Delete(BaseDto dto)
    {
        return await _merchantService.Delete(dto.Id);
    }

    [AllowAnonymous]
    [HttpGet("pass-reset-req")]
    public async Task<Result<bool>> PasswordResetRequest(string email)
    {
        return await _merchantService.ResetPasswordRequest(email);
    }

    [AllowAnonymous]
    [HttpPost("reset-pass")]
    public async Task<Result<bool>> ResetPassword([FromBody] PasswordResetDto dto)
    {
        return await _merchantService.ResetPassword(dto);
    }
}