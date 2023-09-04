using Waitless.DAL;

namespace Waitless.BLL.Services.AdminService;

public class AdminService : IAdminService
{
    private readonly AppDbContext _db;

    public AdminService(AppDbContext db)
    {
        _db = db;
    }
}