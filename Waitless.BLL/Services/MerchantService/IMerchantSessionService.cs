using Ardalis.Result;
using Waitless.BLL.Enums;
using Waitless.DAL.Models;
using Waitless.DTO;
using Waitless.DTO.MerchantDtos;

namespace Waitless.BLL.Services.MerchantService;

public interface IMerchantSessionService
{
    Merchant CurrentMerchant { get; }
   
    Task<Merchant> GetByToken(string token);
    Task<Result<MerchantSessionDto>> Add(LoginDto dto);
    Result<MerchantDto> GetUserCurrentInfo();
    Task<Result<bool>> Delete();
    Task<bool> HasPermission(string requestPath);
    Task<bool> HasPermission(PermissionEnum permissionEnum); 
}