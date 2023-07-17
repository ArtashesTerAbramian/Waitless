using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Waitless.BLL.Filters;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DAL.Models;
using Waitless.DTO.CartDtos;

namespace Waitless.BLL.Services.CartService;

public class CartService : ICartService
{
    private readonly AppDbContext _db;

    public CartService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result> Add(AddCartDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var cart = new Cart()
        {
            UserId = dto.UserId,
            Beverages = dto.BeverageIds.Select(x => new CartBeverage()
            {
                BeverageId = x
            }).ToList()
        };

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
            .Include(x => x.Beverages);

        var carts = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<CartDto>>(await filter.GetPagedInfoAsync(query), carts.MapToCartsDtos());
    }

    public async Task<Result<CartDto>> GetById(long id)
    {
        var cart = await _db.Carts.FirstOrDefaultAsync(x => x.Id == id);

        if(cart == null)
        {
            return Result.NotFound();
        }

        return cart.MapToCartDto();
    }

    public async Task<Result> Update(UpdateCartDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var cart = await _db.Carts.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (cart == null)
        {
            return Result.NotFound();
        }

        cart.Beverages = dto.Beverages.Select(x => new CartBeverage()
        {
            BeverageId = x,
            CartId = cart.Id
        }).ToList();

        scope.Complete();   

        return Result.Success();
    }
}
