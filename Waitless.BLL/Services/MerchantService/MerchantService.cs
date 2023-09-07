using Waitless.DAL;

namespace Waitless.BLL.Services.MerchantService;

public class MerchantService : IMerchantService
{
    private readonly AppDbContext _db;

    public MerchantService(AppDbContext db)
    {
        _db = db;
    }
}