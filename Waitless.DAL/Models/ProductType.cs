namespace Waitless.DAL.Models;

public class BeverageType : BaseEntity
{
    public BeverageType()
    {
        Translations = new HashSet<BeverageTypeTranslation>();
    }
    
    public ICollection<BeverageTypeTranslation> Translations { get; set; }
}