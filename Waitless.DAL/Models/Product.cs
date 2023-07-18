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
    public decimal Price { get; set; }

    public ProductType ProductType { get; set; }
    public BeverageSize ProductSize { get; set; }
    public ICollection<ProductTranslation> Translations { get; set; }
}