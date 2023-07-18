namespace Waitless.DAL.Models;

public class ProductTranslation : BaseTranslationEntity
{
    public long ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Product Product { get; set; }
}