using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.AddressDtos;

namespace Waitless.BLL.Services.AddressService;

public interface IAddressService
{
    Task<PagedResult<List<AddressDto>>> GetAll(AddressFilter filter);
    Task<Result<AddressDto>> GetById(long id);
}