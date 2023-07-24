using System.ComponentModel.DataAnnotations.Schema;

namespace Waitless.DAL.Models;

[NotMapped]
public class Product : BaseWithMedia<ProductPhoto>
{
    public Product()
    {
        Translations = new HashSet<ProductTranslation>();
    }

    public long? ProductTypeId { get; set; }
    public long? ProductSizeId { get; set; }
    public long VendorId { get; set; }
    public decimal Price { get; set; }

    public Vendor Vendor { get; set; }
    public ProductType ProductType { get; set; }
    public ProductSize ProductSize { get; set; }
    public ICollection<ProductTranslation> Translations { get; set; }
}