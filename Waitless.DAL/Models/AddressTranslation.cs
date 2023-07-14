namespace Waitless.DAL.Models;

public class AddressTranslation : BaseTranslationEntity
{
    public long AddressId { get; set; }
    public string Street { get; set; }

    public Address Address { get; set; }
}
