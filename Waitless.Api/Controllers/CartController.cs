using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Waitless.BLL.Filters;
using Waitless.BLL.Services.CartService;
using Waitless.DTO.BeverageDtos;
using Waitless.Dto;
using Waitless.DTO.CartDtos;

namespace Waitless.Api.Controllers;

public class CartController : ApiControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("get-all")]
    public async Task<PagedResult<List<CartDto>>> GetAll([FromQuery] CartFilter filter)
    {
        return await _cartService.GetAll(filter);
    }

    [HttpGet("get-by-id")]
    public async Task<Result<CartDto>> Get(long id)
    {
        return await _cartService.GetById(id);
    }

    [HttpPost("add")]
    public async Task<Result> Add(AddCartDto dto)
    {
        return await _cartService.Add(dto);
    }

    [HttpPost("update")]
    public async Task<Result> Update(UpdateCartDto dto)
    {
        return await _cartService.Update(dto);
    }

    [HttpPost("delete")]
    public async Task<Result> Delete(BaseDto dto)
    {
        return await _cartService.Delete(dto.Id);
    }
}
