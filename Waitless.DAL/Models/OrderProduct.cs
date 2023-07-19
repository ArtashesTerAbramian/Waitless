namespace Waitless.DAL.Models;

public class OrderProduct : BaseEntity
{
    public long ProductId { get; set; }
    public long OrderId { get; set; }

    public Product Product { get; set; }
    public Order Order { get; set; }
}
