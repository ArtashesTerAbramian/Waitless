using Waitless.Dto;

namespace Waitless.DTO.ProductDtos;

public class ProductDto : BaseDto
{
    public long? ProductTypeId { get; set; }
    public long? ProductSizeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<ProductPhotoDto> Files { get; set; }
}
