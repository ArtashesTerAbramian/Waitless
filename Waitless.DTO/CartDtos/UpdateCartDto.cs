namespace Waitless.DTO.CartDtos;

public class UpdateCartDto
{
    public long Id { get; set; }
    public List<long> Products { get; set; }
}
