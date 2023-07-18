namespace Waitless.DAL.Models;

public class ProductType : BaseEntity
{
    public ProductType()
    {
        Translations = new HashSet<ProductTypeTranslation>();
    }
    
    public ICollection<ProductTypeTranslation> Translations { get; set; }
}