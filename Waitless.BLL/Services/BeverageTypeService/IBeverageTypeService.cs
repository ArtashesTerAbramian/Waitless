using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.BeverageDtos;
using Waitless.DTO.BeverageTypeDtos;

namespace Waitless.BLL.Services.BeverageTypeService;

public interface IBeverageTypeService
{
    Task<Result> Add(AddBeverageTypeDto dto);
    Task<Result<BeverageTypeDto>> GetById(long Id);
    Task<PagedResult<List<BeverageTypeDto>>> GetAll(BeverageTypeFilter filter);
    Task<Result> Update(UpdateBeverageTypeDto dto);
    Task<Result> Delete(long id);
}
