using Waitless.DAL.Enums;

namespace Waitless.DAL.Models;

public class ProductSize : BaseEntity
{
    public ProductSize()
    {
        Translations = new HashSet<ProductSizeTranslation>();
    }
    public ProductSizeEnum SizeEnum { get; set; }

    public ICollection<ProductSizeTranslation> Translations { get; set; }

}
