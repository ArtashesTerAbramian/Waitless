using Waitless.DAL.Models;
using Waitless.DTO.ProductDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class ProductSizeMapper
{
    public static ProductSizeDto MapProductSizeDto(this ProductSize productSize)
    {
        var dto = ProductSizeToProductSizeDto(productSize);

        dto.Size = productSize.Translations.First().Size;

        return dto;
    }

    private static partial ProductSizeDto ProductSizeToProductSizeDto(ProductSize productSize);
}
