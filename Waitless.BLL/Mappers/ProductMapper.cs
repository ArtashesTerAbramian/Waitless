using Waitless.DAL.Models;
using Waitless.DTO.ProductDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static ProductDto MapProductDto(this Product product)
    {
        var dto = ProductToProductDto(product);

        dto.Name = product.Translations.First().Name;
        dto.Description = product.Translations.First().Description;

        return dto;
    }

    private static partial ProductDto ProductToProductDto(Product products);
    public static partial List<ProductDto> MapToProductsDtos(this List<Product> products);
}
