using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.CoffeeDtos;

namespace Waitless.BLL.Services.CoffeeService;

public interface ICoffeeService
{
    Task<Result> Add(AddCoffeeDto dto);
    Task<Result> Delete(long id);
    Task<PagedResult<List<CoffeeDto>>> GetAll(CoffeeFilter filter);
    Task<Result<CoffeeDto>> GetById(long id);
    Task<Result> Update(UpdateCoffeeDto dto);
}
