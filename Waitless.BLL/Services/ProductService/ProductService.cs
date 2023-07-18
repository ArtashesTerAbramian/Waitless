using Ardalis.Result;
using Waitless.BLL.Enums;
using Waitless.BLL.Filters;
using Waitless.BLL.Helpers;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Waitless.DTO.ProductDtos;

namespace Waitless.BLL.Services.ProductService;

public class ProductService : IProductService
{
    private readonly AppDbContext _db;
    private readonly FileHelper _fileHelper;

    public ProductService(AppDbContext db,
        FileHelper fileHelper)
    {
        _db = db;
        _fileHelper = fileHelper;
    }
    
    public async Task<Result> Add(AddProductDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var coffee = new Product()
        {
            // ProductTypeId = dto.ProductTypeId ?? null,
            ProductSizeId = dto.ProductSizeId ?? null,
            Price = dto.Price,
            Translations = dto.Translations.Select(x => new ProductTranslation()
            {
                LanguageId = x.LanguageId,
                Description = x.Description,
                Name = x.Name,
            }).ToList(),
        };

        await _db.Product.AddAsync(coffee);

        await _db.SaveChangesAsync();

        if (dto.File != null)
        {
            var folderName = coffee.Translations.First(x => x.LanguageId == (int)LanguageEnum.English).Name;

            var photo = await _fileHelper.UploadFile(dto.File, folderName, null);

            coffee.Files.Add(new ProductPhoto()
            {
                ProductId = coffee.Id,
                FileUrl = photo,
            });

            await _db.SaveChangesAsync();
        }

        scope.Complete();

        return Result.Success();
    }

    public async Task<Result> Delete(long id)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var coffee = await _db.Product
            .Include(x => x.Translations)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (coffee == null)
        {
            return Result.NotFound();
        }

        coffee.IsDeleted = true;

        foreach (var translation in coffee.Translations)
        {
            translation.IsDeleted = true;
        }

        foreach (var photo in coffee.Files)
        {
            photo.IsDeleted = true;
            _fileHelper.DeleteFile(photo.FileUrl);
        }

        await _db.SaveChangesAsync();

        scope.Complete();

        return Result.Success();
    }

    public async Task<PagedResult<List<ProductDto>>> GetAll(ProductFilter filter)
    {
        var query = _db.Product
            .Include(x => x.Translations)
            .Include(x => x.Files);

        var coffees = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<ProductDto>>(await filter.GetPagedInfoAsync(query), coffees.MapToProductsDtos());
    }

    public async Task<Result<ProductDto>> GetById(long id)
    {
        var coffee = await _db.Product
            .Include(x => x.Translations)
            .Include(x => x.Files)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (coffee == null)
        {
            return Result.NotFound();
        }

        return coffee.MapProductDto();
    }

    public async Task<Result> Update(UpdateProductDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var coffee = await _db.Product
            .IgnoreQueryFilters()
            .Include(x => x.Translations)
            .Include(x => x.Files)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (coffee == null)
        {
            return Result.NotFound();
        }

        // coffee.ProductTypeId = dto.ProductTypeId;
        coffee.Price = dto.Price;

        if (dto.Translations != null && dto.Translations.Any())
        {
            foreach (var translationDto in dto.Translations)
            {
                var translation = coffee.Translations.First(x => x.LanguageId == translationDto.LanguageId);

                translation.Name = translation.Name;
                translation.Description = translation.Description;
            }
        }

        if (dto.Photo != null)
        {
            var oldPhoto = coffee.Files.FirstOrDefault();
            if (oldPhoto != null)
            {
                oldPhoto.IsDeleted = true;
            }

            var folderName = coffee.Translations.FirstOrDefault(x => x.LanguageId == (int)LanguageEnum.English).Name;

            var newPhoto = await _fileHelper.UploadFile(dto.Photo, folderName, null);

            coffee.Files.Add(new ProductPhoto()
            {
                ProductId = coffee.Id,
                FileUrl = newPhoto,
            });
        }

        await _db.SaveChangesAsync();

        scope.Complete();

        return Result.Success();
    }


    public async Task<decimal> PriceSumAsync(List<long> ids)
    {
        return await _db.Product.Select(x => x.Price).SumAsync(); 
    }

}
