namespace Waitless.DAL.Models;

public class CartBeverage : BaseEntity
{
    public long BeverageId { get; set; }
    public long CartId { get; set; }

    public Beverage Beverage { get; set; }
    public Cart Cart { get; set; }
}
