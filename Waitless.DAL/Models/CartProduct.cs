namespace Waitless.DAL.Models;

public class CartProduct : BaseEntity
{
    public long ProductId { get; set; }
    public long CartId { get; set; }

    public Product Product { get; set; }
    public Cart Cart { get; set; }
}
