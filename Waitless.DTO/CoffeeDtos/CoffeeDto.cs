using Waitless.Dto;

namespace Waitless.DTO.CoffeeDtos;

public class CoffeeDto : BaseDto
{
    public long? CoffeeTypeId { get; set; }
    public long? BeverageSizeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<CoffeePhotoDto> Files { get; set; }
}
