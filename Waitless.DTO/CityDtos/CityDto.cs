using Waitless.Dto;
using Waitless.DTO.ProvinceDtos;

namespace Waitless.DTO.CityDtos;

public class CityDto : BaseDto
{
    public string Name { get; set; }
    public ProvinceDto Province { get; set; }
}