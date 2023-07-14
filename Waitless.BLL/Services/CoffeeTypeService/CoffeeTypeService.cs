
using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DAL.Models;
using Waitless.DTO.CoffeeTypeDtos;
using Microsoft.EntityFrameworkCore;

namespace Waitless.BLL.Services.CoffeeCategoryService;

public class CoffeeTypeService : ICoffeeTypeService
{
    private readonly AppDbContext _db;

    public CoffeeTypeService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<Result> Add(AddCoffeeTypeDto dto)
    {
        var coffeeType = new CoffeeType()
        {
            Translations = dto.Translations.Select(x => new CoffeeTypeTranslation()
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

    public async Task<PagedResult<List<CoffeeTypeDto>>> GetAll(CoffeeTypeFilter filter)
    {
        var query = _db.CoffeeTypes
            .Include(x => x.Translations);

        var types = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<CoffeeTypeDto>>(await filter.GetPagedInfoAsync(query), types.MapToCoffeeTypesDtos());
    }

    public async Task<Result<CoffeeTypeDto>> GetById(long id)
    {
        var coffeeType = await _db.CoffeeTypes
            .Include(x => x.Translations)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (coffeeType == null)
        {
            return Result.NotFound();
        }

        return coffeeType.MapCoffeeTypeDto();
    }

    public async Task<Result> Update(UpdateCoffeeTypeDto dto)
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
