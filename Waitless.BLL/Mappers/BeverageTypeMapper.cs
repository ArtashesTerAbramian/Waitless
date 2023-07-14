using Waitless.DAL.Models;
using Waitless.DTO.BeverageTypeDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class BeverageTypeMapper
{
    public static BeverageTypeDto MapBeverageTypeDto(this BeverageType type)
    {
        var dto = BeverageTypeToBeverageTypeDto(type);

        dto.Name = type.Translations.First().Name;

        return dto;
    }

    private static partial BeverageTypeDto BeverageTypeToBeverageTypeDto(BeverageType type);
    public static partial List<BeverageTypeDto> MapToBeverageTypesDtos(this List<BeverageType> types);
}
