using Waitless.DAL.Models;
using Waitless.DTO.CoffeeTypeDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class CoffeeTypeMapper
{
    public static CoffeeTypeDto MapCoffeeTypeDto(this CoffeeType type)
    {
        var dto = CoffeeTypeToCoffeeTypeDto(type);

        dto.Name = type.Translations.First().Name;

        return dto;
    }

    private static partial CoffeeTypeDto CoffeeTypeToCoffeeTypeDto(CoffeeType type);
    public static partial List<CoffeeTypeDto> MapToCoffeeTypesDtos(this List<CoffeeType> types);
}
