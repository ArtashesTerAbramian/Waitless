using Waitless.Dto;

namespace Waitless.DTO.BeverageDtos;

public class BeverageDto : BaseDto
{
    public long? BeverageTypeId { get; set; }
    public long? BeverageSizeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<BeveragePhotoDto> Files { get; set; }
}
