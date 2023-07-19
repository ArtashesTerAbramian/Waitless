using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.ProductDtos;
using Waitless.DTO.CartDtos;

namespace Waitless.BLL.Services.CartService;

public interface ICartService
{
    Task<Result> Add(AddCartDto dto);
    Task<PagedResult<List<CartDto>>> GetAll(CartFilter filter);
    Task<Result<CartDto>> GetById(long id);
    Task<PagedResult<List<CartDto>>> GetByUserId(long id);
    Task<Result> Update(UpdateCartDto dto);
}
