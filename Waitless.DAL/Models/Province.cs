namespace Waitless.DAL.Models;

public class Province : BaseEntity
{
    public Province()
    {
        Translations = new HashSet<ProvinceTranslation>();
    }

    public ICollection<ProvinceTranslation> Translations { get; set; }
}
