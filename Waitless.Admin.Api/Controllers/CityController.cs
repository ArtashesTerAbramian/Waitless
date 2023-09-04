using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Services.CityService;
using Waitless.DTO.CityDtos;
using Waitless.DTO.ProvinceDtos;
using Microsoft.AspNetCore.Mvc;

namespace Waitless.Admin.Api.Controllers;

public class CityController : ApiControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }
    
    [HttpGet("get-all")]
    public async Task<PagedResult<List<CityDto>>> GetAll([FromQuery] CityFilter filter)
    {
        return await _cityService.GetAll(filter);
    }

    [HttpGet("get-by-id")]
    public async Task<Result<CityDto>> Get(long id)
    {
        return await _cityService.GetById(id);
    }
}