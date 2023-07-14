using Waitless.DAL.Enums;
using Waitless.Dto;

namespace Waitless.DTO.CoffeeDtos;

public class AddCoffeeDto
{
    public long? CoffeeTypeId { get; set; }
    public long? BeverageSizeId { get; set; }
    public decimal Price { get; set; }
    public List<CoffeeTranslationDto> Translations;
    public FileDto? File { get; set; }
}
