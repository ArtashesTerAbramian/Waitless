namespace Waitless.DAL.Models;

public class ProductSizeTranslation : BaseTranslationEntity
{
    public long ProductSizeId { get; set; }
    public string Size { get; set; }

    public ProductSize ProductSize { get; set; }
}
