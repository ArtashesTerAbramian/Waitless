namespace Waitless.DAL.Models;

public class Cart : BaseEntity
{
    public Cart()
    {
        Beverages = new HashSet<CartBeverage>();
    }
    public long UserId { get; set; }
    public decimal TotalPrice { get; set; }
   

    public ICollection<CartBeverage> Beverages { get; set; }

    public User User { get; set; }

    public override bool Equals(object obj)
    {
        var cart = obj as Cart;

        return UserId == cart.UserId
            && Beverages.SequenceEqual(cart.Beverages);
    }
}
