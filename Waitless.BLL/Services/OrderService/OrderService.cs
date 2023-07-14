using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using Waitless.DTO.OrderDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Waitless.BLL.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly AppDbContext _db;

    public OrderService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result> AddOrderAsync(AddOrderDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var order = new Order()
        {
            UserId = dto.UserId,
            AddressId = dto.AddressId,
            CoffeeIds = dto.CoffeeIds,
            Instruction = dto.Instruction ?? string.Empty,
            TimingType = dto.OrderTimingType,
            BeReadyOn = dto.BeReadyOn
        };

        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();

        scope.Complete();

        return Result.Success();
    }

    public async Task<Result> Delete(long id)
    {
        var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == id);

        if(order == null) 
        {
            return Result.NotFound();
        }

        order.IsDeleted = true;

        await _db.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<PagedResult<List<OrderDto>>> GetAllAsync(OrderFilter filter)
    {
        var query = _db.Orders;

        var orders = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<OrderDto>>(await filter.GetPagedInfoAsync(query), orders.MapToOrdersDtos());
    }

    public async Task<Result<OrderDto>> GetByIdAsync(long id)
    {
        var order = await _db.Orders
            .FirstOrDefaultAsync(x => x.Id == id);

        if(order == null)
        {
            return Result.NotFound();
        }

        return order.MapToOrderDto();
    }

    public async Task<Result> UpdateAsync(UpdateOrderDto dto)
    {
        var order = await _db.Orders
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if(order == null)
        {
            return Result.NotFound();
        }

        TimeSpan elapsedTime = DateTime.UtcNow - order.CreatedDate;
        if (elapsedTime > TimeSpan.FromMinutes(5))
        {
            return Result.Error("Cant Update order after 5 minits from ordered time");
        }

        order.AddressId = dto.AddressId;
        order.CoffeeIds = dto.CoffeeIds;
        order.BeReadyOn = dto.BeReadyOn;
        order.Instruction = dto.Instruction;
        order.TimingType = dto.OrderTimingType;

        await _db.SaveChangesAsync();
    
        return Result.Success();
    }
}
