using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DAL.Models;
using Waitless.DTO.CoffeeTypeDtos;

namespace Waitless.BLL.Services.CoffeeCategoryService;

public interface ICoffeeTypeService
{
    Task<Result> Add(AddCoffeeTypeDto dto);
    Task<Result<CoffeeTypeDto>> GetById(long Id);
    Task<PagedResult<List<CoffeeTypeDto>>> GetAll(CoffeeTypeFilter filter);
    Task<Result> Update(UpdateCoffeeTypeDto dto);
    Task<Result> Delete(long id);
}
