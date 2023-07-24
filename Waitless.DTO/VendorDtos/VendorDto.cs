using Waitless.Dto;
using Waitless.DTO.AddressDtos;
using Waitless.DTO.ProductDtos;

namespace Waitless.DTO.VendorDtos;

public class VendorDto : BaseDto
{
    public string Name { get; set; }
    public List<ProductDto> Products { get; set; }
    public List<AddAddressDto> Addresses { get; set; }
}
