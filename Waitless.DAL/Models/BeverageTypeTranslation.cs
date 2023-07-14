namespace Waitless.DAL.Models;

public class BeverageTypeTranslation : BaseTranslationEntity
{
    public long BeverageTypeId { get; set; }
    public string Name { get; set; }

    public BeverageType BeverageType { get; set; }
}
