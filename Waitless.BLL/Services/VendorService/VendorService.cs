using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Helpers;
using Waitless.DAL;
using Waitless.DTO.VendorDtos;

namespace Waitless.BLL.Services.VendorService;

public class VendorService : IVendorService
{
    private readonly AppDbContext _db;
    private readonly FileHelper _fileHelper;

    public VendorService(AppDbContext db,
        FileHelper fileHelper)
    {
        _db = db;
        _fileHelper = fileHelper;
    }

    public Task<Result> AddVendorAsync(AddVendorDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<List<VendorDto>>> GetAllAsync(VendorFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<Result<VendorDto>> GetByTokenAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateAsync(UpdateVendorDto dto)
    {
        throw new NotImplementedException();
    }
}
