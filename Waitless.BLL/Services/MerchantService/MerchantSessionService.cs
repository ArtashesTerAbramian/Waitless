using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Waitless.BLL.Enums;
using Waitless.BLL.Models;
using Waitless.DAL;
using Waitless.DAL.Models;
using Waitless.DTO;
using Waitless.DTO.MerchantDtos;

namespace Waitless.BLL.Services.MerchantService;

public class MerchantSessionService : IMerchantSessionService
{
    private readonly AppDbContext _db;
    private readonly AuthOptions _options;
    public Merchant CurrentMerchant { get; }

    public MerchantSessionService(AppDbContext db,
        IOptions<AuthOptions> options)
    {
        _db = db;
        _options = options.Value;
    }

    public async Task<Merchant> GetByToken(string token)
    {
        var merchantSession = await _db.MerchantSessions
            .Include(x => x.Merchant)
            .FirstOrDefaultAsync(x => x.Token.Trim() == token.Trim());

        if (merchantSession is null)
        {
            return null;
        }

        if (merchantSession.ModifyDate.Value.AddMinutes(_options.TokenExpirationTimeInMinutes) < DateTime.Now)
        {
            merchantSession.IsExpired = true;

            await _db.SaveChangesAsync();

            return null;
        }

        merchantSession.ModifyDate = DateTime.Now;

        await _db.SaveChangesAsync();

        return merchantSession.Merchant;
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