using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Services.BeverageService;
using Waitless.Dto;
using Waitless.DTO.BeverageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Waitless.Api.Controllers
{
    public class BeverageController : ApiControllerBase
    {
        private readonly IBeverageService _beverageService;

        public BeverageController(IBeverageService beverageService)
        {
            _beverageService = beverageService;
        }

        [HttpGet("get-all")]
        public async Task<PagedResult<List<BeverageDto>>> GetAll([FromQuery] BeverageFilter filter)
        {
            return await _beverageService.GetAll(filter);
        }

        [HttpGet("get-by-id")]
        public async Task<Result<BeverageDto>> Get(long id)
        {
            return await _beverageService.GetById(id);
        }

        [HttpPost("add")]
        public async Task<Result> Add(AddBeverageDto dto)
        {
            return await _beverageService.Add(dto);
        }

        [HttpPost("update")]
        public async Task<Result> Update(UpdateBeverageDto dto)
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
