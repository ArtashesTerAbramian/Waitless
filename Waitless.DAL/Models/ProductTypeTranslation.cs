namespace Waitless.DAL.Models;

public class ProductTypeTranslation : BaseTranslationEntity
{
    public long ProductTypeId { get; set; }
    public string Name { get; set; }

    public ProductType ProductType { get; set; }
}