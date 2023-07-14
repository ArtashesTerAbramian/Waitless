using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.ProvinceDtos;

namespace Waitless.BLL.Services.ProvinceService;

public interface IProvinceService
{
    Task<PagedResult<List<ProvinceDto>>> GetAll(ProvinceFilter filter);
    Task<Result<ProvinceDto>> GetById(long id);
}
