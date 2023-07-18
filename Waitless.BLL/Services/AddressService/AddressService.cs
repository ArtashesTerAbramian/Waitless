using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DTO.AddressDtos;
using Waitless.DTO.CityDtos;
using Microsoft.EntityFrameworkCore;

namespace Waitless.BLL.Services.AddressService;

public class AddressService : IAddressService
{
    private readonly AppDbContext _db;

    public AddressService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<PagedResult<List<AddressDto>>> GetAll(AddressFilter filter)
    {
        var query = _db.Addresses
            .Include(x => x.Translations);

        var addresses = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<AddressDto>>(await filter.GetPagedInfoAsync(query), addresses.MapToAddressDtos());
    }

    public async Task<Result<AddressDto>> GetById(long id)
    {
        var address = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == id);

        if (address is null)
        {
            return Result.NotFound();
        }

        return address.MapProvinceDto();
    }
}