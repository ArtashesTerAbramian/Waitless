namespace Waitless.DAL.Models;

public class BeverageTranslation : BaseTranslationEntity
{
    public long BeverageId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Beverage Beverage { get; set; }
}