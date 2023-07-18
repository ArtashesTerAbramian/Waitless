using Waitless.DAL.Enums;
using Waitless.Dto;

namespace Waitless.DTO.ProductDtos;

public class AddProductDto
{
    public long? ProductTypeId { get; set; }
    public long? ProductSizeId { get; set; }
    public decimal Price { get; set; }
    public List<ProductTranslationDto> Translations;
    public FileDto? File { get; set; }
}
