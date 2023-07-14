using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Services.CoffeeService;
using Waitless.Dto;
using Waitless.DTO.CoffeeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Waitless.Api.Controllers
{
    public class CoffeeController : ApiControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet("get-all")]
        public async Task<PagedResult<List<CoffeeDto>>> GetAll([FromQuery] CoffeeFilter filter)
        {
            return await _coffeeService.GetAll(filter);
        }

        [HttpGet("get-by-id")]
        public async Task<Result<CoffeeDto>> Get(long id)
        {
            return await _coffeeService.GetById(id);
        }

        [HttpPost("add")]
        public async Task<Result> Add(AddCoffeeDto dto)
        {
            return await _coffeeService.Add(dto);
        }

        [HttpPost("update")]
        public async Task<Result> Update(UpdateCoffeeDto dto)
        {
            return await _coffeeService.Update(dto);
        }

        [HttpPost("delete")]
        public async Task<Result> Delete(BaseDto dto)
        {
            return await _coffeeService.Delete(dto.Id);
        }
    }
}
