using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Waitless.BLL.Filters;
using Waitless.BLL.Services.VendorService;
using Waitless.Dto;
using Waitless.DTO.VendorDtos;

namespace Waitless.Admin.Api.Controllers;

[Route("api/vendor")]
public class VendorController : ApiControllerBase
{
    private readonly IVendorService _vendorService;

    public VendorController(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    [HttpGet("get-all")]
    public async Task<PagedResult<List<VendorDto>>> GetAll([FromQuery] VendorFilter filter)
    {
        return await _vendorService.GetAllAsync(filter);
    }

    [HttpGet("get-by-id")]
    public async Task<Result<VendorDto>> Get(long id)
    {
        return await _vendorService.GetByTokenAsync(id);
    }

    [HttpPost("add")]
    public async Task<Result> Add(AddVendorDto dto)
    {
        return await _vendorService.AddVendorAsync(dto);
    }

    [HttpPost("update")]
    public async Task<Result> Update(UpdateVendorDto dto)
    {
        return await _vendorService.UpdateAsync(dto);
    }

    [HttpPost("delete")]
    public async Task<Result> Delete(BaseDto dto)
    {
        return await _vendorService.Delete(dto.Id);
    }
}
