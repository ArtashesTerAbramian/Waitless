using Waitless.Dto;

namespace Waitless.DTO.CartDtos;

public class CartDto : BaseDto
{
    public long UserId { get; set; }
    public decimal? TotalPrice { get; set; }
    public List<CartProductDto> Products { get; set; }
}
