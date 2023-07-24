
using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.VendorDtos;

namespace Waitless.BLL.Services.VendorService;

public interface IVendorService
{
    Task<Result> AddVendorAsync(AddVendorDto dto);
    Task<Result> Delete(long id);
    Task<PagedResult<List<VendorDto>>> GetAllAsync(VendorFilter filter);
    Task<Result<VendorDto>> GetByTokenAsync(long id);
    Task<Result> UpdateAsync(UpdateVendorDto dto);
}
