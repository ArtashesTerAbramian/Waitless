using Ardalis.Result;
using Waitless.BLL.Services.OrderService;
using Waitless.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Waitless.DTO.OrderDtos;
using Waitless.BLL.Filters;

namespace Waitless.Api.Controllers;

public class OrderController : ApiControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("get-all")]
    public async Task<PagedResult<List<OrderDto>>> GetAll([FromQuery] OrderFilter filter)
    {
        return await _orderService.GetAllAsync(filter);
    }

    [HttpGet("get-by-id")]
    public async Task<Result<OrderDto>> Get(long id)
    {
        return await _orderService.GetByIdAsync(id);
    }

    [HttpPost("add")]
    public async Task<Result> Add(AddOrderDto dto)
    {
        return await _orderService.AddOrderAsync(dto);
    }

    [HttpPost("update")]
    [DisableRequestSizeLimit]
    public async Task<Result> Update(UpdateOrderDto dto)
    {
        return await _orderService.UpdateAsync(dto);
    }

    [HttpPost("update-order-by-order-id")]
    public async Task<Result> Delete(UpdateOrderProductsDto dto)
    {
        return await _orderService.UpdateOrderProductsAsync(dto);
    }
}
