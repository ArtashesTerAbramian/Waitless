using Waitless.DAL.Models;

namespace Waitless.DTO.CartDtos;

public class AddCartDto
{
    public long UserId { get; set; }
    public List<long> ProductIds { get; set; }
}
