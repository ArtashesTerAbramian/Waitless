using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Waitless.BLL.Filters;
using Waitless.BLL.Helpers;
using Waitless.BLL.Mappers;
using Waitless.BLL.Services.ProductService;
using Waitless.DAL;
using Waitless.DAL.Models;
using Waitless.DTO.CartDtos;

namespace Waitless.BLL.Services.CartService;

public class CartService : ICartService
{
    private readonly AppDbContext _db;
    private readonly IProductService _productService;

    public CartService(AppDbContext db,
        IProductService productService)
    {
        _db = db;
        _productService = productService;
    }

    public async Task<Result> Add(AddCartDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var cart = new Cart()
        {
            UserId = dto.UserId,
            Products = dto.ProductIds.Select(x => new CartProduct()
            {
                ProductId = x
            }).ToList()
        };

        cart.TotalPrice = await _productService.PriceSumAsync(dto.ProductIds);

        var userCart = await _db.Carts
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.UserId == cart.UserId);
        if (userCart is not null)
        {
            CartProductsComparer comparer = new CartProductsComparer();

            bool areEqual = Enumerable.SequenceEqual(cart.Products, userCart?.Products, comparer);


            if (areEqual)
            {
                return Result.Success();
            }

            userCart.IsDeleted = true;
        }


        await _db.Carts.AddAsync(cart);
        await _db.SaveChangesAsync();

        scope.Complete();

        return Result.Success();
    }

    public Task<Result> Delete(long id)
    {
        throw new NotImplementedException("No need to delete anything from cart");
    }

    public async Task<PagedResult<List<CartDto>>> GetAll(CartFilter filter)
    {
        var query = _db.Carts
            .Include(x => x.Products);

        var carts = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<CartDto>>(await filter.GetPagedInfoAsync(query), carts.MapToCartsDtos());
    }

    public async Task<Result<CartDto>> GetById(long id)
    {
        var cart = await _db.Carts.FirstOrDefaultAsync(x => x.Id == id);

        if (cart is null)
        {
            return Result.NotFound();
        }

        return cart.MapToCartDto();
    }


    public async Task<PagedResult<List<CartDto>>> GetByUserId(long id)
    {
        var cart = await _db.Carts
            .Include(x => x.Products)
            .Where(x => x.UserId == id)
            .ToListAsync();

        return new PagedResult<List<CartDto>>(
            new PagedInfo(10, cart.Count, 10, cart.Count), cart.MapToCartsDtos());
    }

    public async Task<Result> Update(UpdateCartDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var cart = await _db.Carts.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (cart is null)
        {
            return Result.NotFound();
        }

        cart.Products = dto.Products.Select(x => new CartProduct()
        {
            ProductId = x,
            CartId = cart.Id
        }).ToList();

        scope.Complete();

        return Result.Success();
    }
}
