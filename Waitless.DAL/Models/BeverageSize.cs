using Waitless.DAL.Enums;

namespace Waitless.DAL.Models;

public class BeverageSize : BaseEntity
{
    public BeverageSize()
    {
        Translations = new HashSet<BeverageSizeTranslation>();
    }
    public BeverageSizeEnum SizeEnum { get; set; }

    public ICollection<BeverageSizeTranslation> Translations { get; set; }

}
