using Waitless.DAL.Models;
using Waitless.DTO.BeverageDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class BeverageMapper
{
    public static BeverageDto MapCoffeeDto(this Beverage beverage)
    {
        var dto = BeverageToBeverageDto(beverage);

        dto.Name = beverage.Translations.First().Name;
        dto.Description = beverage.Translations.First().Description;

        return dto;
    }

    private static partial BeverageDto BeverageToBeverageDto(Beverage beverage);
    public static partial List<BeverageDto> MapToBeveragesDtos(this List<Beverage> beverages);
}
