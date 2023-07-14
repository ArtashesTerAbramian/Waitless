using Waitless.Dto;

namespace Waitless.DTO.AddressDtos;

public class AddressDto : BaseDto
{
    public long CityId { get; set; }
    public string? PostalCode { get; set; }
    public string Street { get; set; }
}