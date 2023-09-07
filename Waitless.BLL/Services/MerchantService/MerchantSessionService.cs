using Ardalis.Result;
using Waitless.BLL.Enums;
using Waitless.DAL.Models;
using Waitless.DTO;
using Waitless.DTO.MerchantDtos;

namespace Waitless.BLL.Services.MerchantService;

public class MerchantSessionService : IMerchantSessionService
{
    public Merchant CurrentMerchant { get; }
    
    public Task<Merchant> GetByToken(string token)
    {
        throw new NotImplementedException();
    }

    public Task<Result<MerchantSessionDto>> Add(LoginDto dto)
    {
        throw new NotImplementedException();
    }

    public Result<MerchantDto> GetUserCurrentInfo()
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> Delete()
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasPermission(string requestPath)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasPermission(PermissionEnum permissionEnum)
    {
        throw new NotImplementedException();
    }
}