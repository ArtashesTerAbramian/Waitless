namespace Waitless.DAL.Models;

public class CoffeeTranslation : BaseTranslationEntity
{
    public long CoffeeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Coffee Coffee { get; set; }
}
