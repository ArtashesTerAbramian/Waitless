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

        if (dto.File is { })
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

        var product = await _db.Product
            .Include(x => x.Translations)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product is null)
        {
            return Result.NotFound();
        }

        product.IsDeleted = true;

        foreach (var translation in product.Translations)
        {
            translation.IsDeleted = true;
        }

        foreach (var photo in product.Files)
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

        var products = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<ProductDto>>(await filter.GetPagedInfoAsync(query), products.MapToProductsDtos());
    }

    public async Task<Result<ProductDto>> GetById(long id)
    {
        var product = await _db.Product
            .Include(x => x.Translations)
            .Include(x => x.Files)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product is null)
        {
            return Result.NotFound();
        }

        return product.MapProductDto();
    }

    public async Task<Result> Update(UpdateProductDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var product = await _db.Product
            .IgnoreQueryFilters()
            .Include(x => x.Translations)
            .Include(x => x.Files)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (product is null)
        {
            return Result.NotFound();
        }

        product.ProductTypeId = dto.ProductTypeId;
        product.Price = dto.Price;

        if (dto.Translations is null && dto.Translations.Any())
        {
            foreach (var translationDto in dto.Translations)
            {
                var translation = product.Translations.First(x => x.LanguageId == translationDto.LanguageId);

                translation.Name = translation.Name;
                translation.Description = translation.Description;
            }
        }

        if (dto.Photo is {})
        {
            var oldPhoto = product.Files.FirstOrDefault();
            if (oldPhoto is {})
            {
                oldPhoto.IsDeleted = true;
            }

            var folderName = product.Translations.FirstOrDefault(x => x.LanguageId == (int)LanguageEnum.English).Name;

            var newPhoto = await _fileHelper.UploadFile(dto.Photo, folderName, null);

            product.Files.Add(new ProductPhoto()
            {
                ProductId = product.Id,
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
