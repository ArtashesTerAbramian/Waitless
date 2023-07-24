using Waitless.DTO.AddressDtos;

namespace Waitless.DTO.VendorDtos;

public class UpdateVendorDto
{
    public string Name { get; set; }
    public List<UpdateAddressDto> Addresses { get; set; }
}
