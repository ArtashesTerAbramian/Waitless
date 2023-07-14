namespace Waitless.DAL.Models;

public class Address : BaseEntity
{
    public Address()
    {
        Translations = new HashSet<AddressTranslation>();
    }
    public long CityId { get; set; }
    public string? PostalCode { get; set; }

    public City City { get; set; }

    public ICollection<AddressTranslation> Translations { get; set; }
}