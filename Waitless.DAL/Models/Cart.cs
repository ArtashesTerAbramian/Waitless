namespace Waitless.DAL.Models;

public class Cart : BaseEntity
{
    public Cart()
    {
        Products = new HashSet<CartProduct>();
    }
    public long UserId { get; set; }
    public decimal TotalPrice { get; set; }
   

    public ICollection<CartProduct> Products { get; set; }

    public User User { get; set; }

    public override bool Equals(object obj)
    {
        var cart = obj as Cart;

        return UserId == cart.UserId
            && Products.SequenceEqual(cart.Products);
    }
}
