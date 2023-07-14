namespace Waitless.DAL.Models;

public class BeverageSizeTranslation : BaseTranslationEntity
{
    public long BeverageSizeId { get; set; }
    public string Size { get; set; }

    public BeverageSize BeverageSize { get; set; }
}
