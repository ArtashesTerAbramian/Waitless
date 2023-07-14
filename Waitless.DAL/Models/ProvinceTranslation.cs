namespace Waitless.DAL.Models;

public class ProvinceTranslation : BaseTranslationEntity
{
    public long ProvinceId { get; set; }
    public string Name { get; set; }

    public Province Province { get; set; }
}
