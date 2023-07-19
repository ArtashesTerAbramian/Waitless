namespace Waitless.DTO.OrderDtos;

public class UpdateOrderProductsDto
{
    public List<long> ProductIds { get; set; }
    public long OrderId { get; set; }
}
