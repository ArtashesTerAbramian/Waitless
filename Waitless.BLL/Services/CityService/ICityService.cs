using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.CityDtos;

namespace Waitless.BLL.Services.CityService;

public interface ICityService
{
    Task<Result<CityDto>> GetById(long id);
    Task<PagedResult<List<CityDto>>> GetAll(CityFilter filter);
}