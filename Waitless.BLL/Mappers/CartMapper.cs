using Riok.Mapperly.Abstractions;
using Waitless.DAL.Models;
using Waitless.DTO.CartDtos;

namespace Waitless.BLL.Mappers
{
    [Mapper]
    public static partial class CartMapper
    {
        public static partial CartDto MapToCartDto(this Cart cart);
        public static partial List<CartDto> MapToCartsDtos(this List<Cart> carts);
    }
}
