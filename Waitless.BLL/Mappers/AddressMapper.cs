using Waitless.DAL.Models;
using Waitless.DTO.AddressDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class AddressMapper
{
    public static AddressDto MapProvinceDto(this Address address)
    {
        var dto = AddressToAddressDto(address);

        dto.Street = address.Translations.First().Street;

        return dto;
    }

    private static partial AddressDto AddressToAddressDto(Address address);
    public static partial List<AddressDto> MapToAddressDtos(this List<Address> addresses);

}