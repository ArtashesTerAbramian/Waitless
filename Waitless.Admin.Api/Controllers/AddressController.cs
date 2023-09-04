using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Services.AddressService;
using Waitless.DTO.AddressDtos;
using Microsoft.AspNetCore.Mvc;

namespace Waitless.Admin.Api.Controllers;

public class AddressController : ApiControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }
    
    [HttpGet("get-all")]
    public async Task<PagedResult<List<AddressDto>>> GetAll([FromQuery] AddressFilter filter)
    {
        return await _addressService.GetAll(filter);
    }

    [HttpGet("get-by-id")]
    public async Task<Result<AddressDto>> Get(long id)
    {
        return await _addressService.GetById(id);
    }
}