using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.DTO.ProductDtos;

namespace Waitless.BLL.Services.ProductService;

public interface IProductService
{
    Task<Result> Add(AddProductDto dto);
    Task<Result> Delete(long id);
    Task<PagedResult<List<ProductDto>>> GetAll(ProductFilter filter);
    Task<Result<ProductDto>> GetById(long id);
    Task<Result> Update(UpdateProductDto dto);
    Task<decimal> PriceSumAsync(List<long> ids); 
}
