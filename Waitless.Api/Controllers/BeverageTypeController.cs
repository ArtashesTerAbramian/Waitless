using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.Dto;
using Microsoft.AspNetCore.Mvc;
using Waitless.BLL.Services.BeverageTypeService;
using Waitless.DTO.BeverageTypeDtos;

namespace Waitless.Api.Controllers
{
    public class BeverageTypeController : ApiControllerBase
    {
        private readonly IBeverageTypeService _beverageCategoryService;

        public BeverageTypeController(IBeverageTypeService beverageCategoryService)
        {
            _beverageCategoryService = beverageCategoryService;
        }

        [HttpGet("get-all")]
        public async Task<PagedResult<List<BeverageTypeDto>>> GetAll([FromQuery] BeverageTypeFilter filter)
        {
            return await _beverageCategoryService.GetAll(filter);
        }

        [HttpGet("get-by-id")]
        public async Task<Result<BeverageTypeDto>> Get(long id)
        {
            return await _beverageCategoryService.GetById(id);
        }

        [HttpPost("add")]
        [DisableRequestSizeLimit]
        public async Task<Result> Add(AddBeverageTypeDto dto)
        {
            return await _beverageCategoryService.Add(dto);
        }

        [HttpPost("update")]
        [DisableRequestSizeLimit]
        public async Task<Result> Update(UpdateBeverageTypeDto dto)
        {
            return await _beverageCategoryService.Update(dto);
        }

        [HttpPost("delete")]
        public async Task<Result> Delete(BaseDto dto)
        {
            return await _beverageCategoryService.Delete(dto.Id);
        }
    }
}
