using Waitless.DTO.AddressDtos;

namespace Waitless.DTO.VendorDtos;

public class AddVendorDto
{
    public string Name { get; set; }
    public List<AddAddressDto> Addresses { get; set; }
}
