using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Services.ProductService;
using Waitless.Dto;
using Waitless.DTO.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace Waitless.Api.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _beverageService;

        public ProductController(IProductService beverageService)
        {
            _beverageService = beverageService;
        }

        [HttpGet("get-all")]
        public async Task<PagedResult<List<ProductDto>>> GetAll([FromQuery] ProductFilter filter)
        {
            return await _beverageService.GetAll(filter);
        }

        [HttpGet("get-by-id")]
        public async Task<Result<ProductDto>> Get(long id)
        {
            return await _beverageService.GetById(id);
        }

        [HttpPost("add")]
        public async Task<Result> Add(AddProductDto dto)
        {
            return await _beverageService.Add(dto);
        }

        [HttpPost("update")]
        public async Task<Result> Update(UpdateProductDto dto)
        {
            return await _beverageService.Update(dto);
        }

        [HttpPost("delete")]
        public async Task<Result> Delete(BaseDto dto)
        {
            return await _beverageService.Delete(dto.Id);
        }
    }
}
