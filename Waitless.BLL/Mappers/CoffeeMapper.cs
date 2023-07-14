using Waitless.DAL.Models;
using Waitless.DTO.CoffeeDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class CoffeeMapper
{
    public static CoffeeDto MapCoffeeDto(this Coffee coffee)
    {
        var dto = CoffeeToCoffeeDto(coffee);

        dto.Name = coffee.Translations.First().Name;
        dto.Description = coffee.Translations.First().Description;

        return dto;
    }

    private static partial CoffeeDto CoffeeToCoffeeDto(Coffee coffee);
    public static partial List<CoffeeDto> MapToCoffeesDtos(this List<Coffee> coffees);
}
