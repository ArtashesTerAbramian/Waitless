
using Waitless.DAL.Models;

namespace Waitless.DTO.AddressDtos;

public class AddAddressDto
{
    public long CityId { get; set; }
    public string? PostalCode { get; set; }

    public List<AddressTranslationDto> Translations { get; set; }
}
