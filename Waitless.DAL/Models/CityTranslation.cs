namespace Waitless.DAL.Models;

public class CityTranslation : BaseTranslationEntity
{
    public long CityId { get; set; }
    public string Name { get; set; }

    public City City { get; set; }
}
