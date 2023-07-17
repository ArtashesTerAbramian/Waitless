using System.ComponentModel.DataAnnotations.Schema;

namespace Waitless.DAL.Models;

[NotMapped]
public class Beverage : BaseWithMedia<BeveragePhoto>
{
    public Beverage()
    {
        Translations = new HashSet<BeverageTranslation>();
    }

    public long? BeverageTypeId { get; set; }
    public long? BeverageSizeId { get; set; }
    public decimal Price { get; set; }

    public BeverageType BeverageType { get; set; }
    public BeverageSize BeverageSize { get; set; }
    public ICollection<BeverageTranslation> Translations { get; set; }
}