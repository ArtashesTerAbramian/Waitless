using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.BeverageDtos;

namespace Waitless.BLL.Services.BeverageService;

public interface IBeverageService
{
    Task<Result> Add(AddBeverageDto dto);
    Task<Result> Delete(long id);
    Task<PagedResult<List<BeverageDto>>> GetAll(BeverageFilter filter);
    Task<Result<BeverageDto>> GetById(long id);
    Task<Result> Update(UpdateBeverageDto dto);
}
