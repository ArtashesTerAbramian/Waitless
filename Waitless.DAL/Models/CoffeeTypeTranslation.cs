namespace Waitless.DAL.Models;

public class CoffeeTypeTranslation : BaseTranslationEntity
{
    public long CoffeeTypeId { get; set; }
    public string Name { get; set; }

    public CoffeeType CoffeeType { get; set; }
}
