namespace Waitless.DAL.Models;

public class Vendor : BaseWithMedia<VendorPhoto>
{
    public Vendor()
    {
        Addresses = new HashSet<Address>();
        Products = new HashSet<Product>();
    }

    public string Name { get; set; }

    public ICollection<Address> Addresses { get; set; }
    public ICollection<Product> Products { get; set; }

}
