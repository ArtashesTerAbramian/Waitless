using Waitless.DAL.Models;
using Waitless.DTO.CityDtos;
using Waitless.DTO.ProvinceDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class CityMapper
{
    public static CityDto MapProvinceDto(this City city)
    {
        var dto = CityToCityDto(city);

        dto.Name = city.Translations.First().Name;
        dto.Province = city.Province.MapProvinceDto();

        return dto;
    }

    private static partial CityDto CityToCityDto(City city);
    public static partial List<CityDto> MapToCityDtos(this List<City> cities);
}