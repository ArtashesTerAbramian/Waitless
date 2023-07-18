
using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DTO.ProvinceDtos;
using Microsoft.EntityFrameworkCore;

namespace Waitless.BLL.Services.ProvinceService;

public class ProvinceService : IProvinceService
{
    private readonly AppDbContext _db;

    public ProvinceService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<PagedResult<List<ProvinceDto>>> GetAll(ProvinceFilter filter)
    {
        var query = _db.Provinces
            .Include(x => x.Translations);

        var provinces = await filter.FilterObjects(query)
            .ToListAsync();

        return new PagedResult<List<ProvinceDto>>(await filter.GetPagedInfoAsync(query), provinces.MapToProvincesDtos());
    }

    public async Task<Result<ProvinceDto>> GetById(long id)
    {
        var province = await _db.Provinces
            .Include(x => x.Translations)
            .FirstOrDefaultAsync(x => x.Id == id);

        if(province is null)
        {
            return Result.NotFound();
        }

        return province.MapProvinceDto();
    }
}
