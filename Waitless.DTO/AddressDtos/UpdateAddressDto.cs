
namespace Waitless.DTO.AddressDtos;

public class UpdateAddressDto
{
    public long CityId { get; set; }
    public string? PostalCode { get; set; }

    public List<AddressTranslationDto> Translations { get; set; }
}
