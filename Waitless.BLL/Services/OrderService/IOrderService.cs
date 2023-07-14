using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.OrderDtos;

namespace Waitless.BLL.Services.OrderService;

public interface IOrderService
{
    Task<Result> AddOrderAsync(AddOrderDto dto);
    Task<Result> Delete(long id);
    Task<PagedResult<List<OrderDto>>> GetAllAsync(OrderFilter filter);
    Task<Result<OrderDto>> GetByIdAsync(long id);
    Task<Result> UpdateAsync(UpdateOrderDto dto);
}
