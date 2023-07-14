using Waitless.DAL.Models;
using Waitless.DTO.CoffeeDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class BeverageSizeMapper
{
    public static BeverageSizeDto MapBeverageSizeDto(this BeverageSize province)
    {
        var dto = BeverageSizeToBeverageSizeDto(province);

        dto.Size = province.Translations.First().Size;

        return dto;
    }

    private static partial BeverageSizeDto BeverageSizeToBeverageSizeDto(BeverageSize province);
}
