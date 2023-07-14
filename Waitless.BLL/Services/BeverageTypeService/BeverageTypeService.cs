using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Waitless.DTO.BeverageDtos;
using Waitless.DTO.BeverageTypeDtos;

namespace Waitless.BLL.Services.BeverageTypeService;

public class BeverageTypeService : IBeverageTypeService
{
    private readonly AppDbContext _db;

    public BeverageTypeService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Result> Add(AddBeverageTypeDto dto)
    {
        var coffeeType = new BeverageType()
        {
            Translations = dto.Translations.Select(x => new BeverageTypeTranslation()
            {
                Name = x.Name,
                LanguageId = x.LanguageId,
            }).ToList(),
        };

        await _db.CoffeeTypes.AddAsync(coffeeType);

        await _db.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> Delete(long id)
    {
        var coffeeType = await _db.CoffeeTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (coffeeType == null) 
        {
            return Result.NotFound();        
        }

        coffeeType.IsDeleted = true;

        foreach (var translation in coffeeType.Translations)
        {
            translation.IsDeleted = true;
        }

        await _db.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<PagedResult<List<BeverageTypeDto>>> GetAll(BeverageTypeFilter filter)
    {
        var query = _db.CoffeeTypes
            .Include(x => x.Translations);

        var types = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<BeverageTypeDto>>(await filter.GetPagedInfoAsync(query), types.MapToBeverageTypesDtos());
    }
    
    public async Task<Result<BeverageTypeDto>> GetById(long id)
    {
        var coffeeType = await _db.CoffeeTypes
            .Include(x => x.Translations)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (coffeeType == null)
        {
            return Result.NotFound();
        }

        return coffeeType.MapBeverageTypeDto();
    }

    public async Task<Result> Update(UpdateBeverageTypeDto dto)
    {
        var coffeeType = await _db.CoffeeTypes
            .IgnoreQueryFilters()
            .Include(x => x.Translations)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if(coffeeType == null)
        {
            return Result.NotFound();
        }

        foreach (var translationDto in dto.Translations)
        {
            var translation = coffeeType.Translations
                .First(x => x.LanguageId == translationDto.LanguageId);

            translation.Name = translationDto.Name;
        }

        await _db.SaveChangesAsync();

        return Result.Success();
    }
}
