using Ardalis.Result;
using Waitless.DTO.MerchantDtos;
using Waitless.DTO;
using Waitless.DTO.UsersDtos;

namespace Waitless.BLL.Services.MerchantService;

public interface IMerchantService
{
    Task<Result<MerchantDto>> GetByTokenAsync(string token);
    Task<Result<MerchantDto>> GetMerchantByUsernameAsync(string username);
    Task<Result> AddMerchantAsync(AddMerchantDto dto);
    Task<Result<bool>> VerifyMerchantAsync(string token);
    Task<Result> UpdateAsync(UpdateMerchantDto dto);
    Task<Result> Delete(long dtoId);
    Task<Result<bool>> ResetPasswordRequest(string email);
    Task<Result<bool>> ResetPassword(PasswordResetDto dto);
}