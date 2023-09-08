using Ardalis.Result;
using Waitless.BLL.Filters;
using Waitless.BLL.Mappers;
using Waitless.DAL;
using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using Waitless.DTO.OrderDtos;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Reflection;
using Waitless.BLL.Constants;
using Waitless.BLL.Services.ErrorService;
using Waitless.BLL.Services.ProductService;

namespace Waitless.BLL.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly AppDbContext _db;
    private readonly IProductService _productService;
    private readonly IErrorService _errorService;

    public OrderService(AppDbContext db,
        IProductService productService,
        IErrorService errorService)
    {
        _db = db;
        _productService = productService;
        _errorService = errorService;
    }

    public async Task<Result> AddOrderAsync(AddOrderDto dto)
    {
        using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var order = new Order()
        {
            UserId = dto.UserId,
            AddressId = dto.AddressId,
            Instruction = dto.Instruction ?? string.Empty,
            TimingType = dto.OrderTimingType ?? OrderTimingType.ASAP,
            BeReadyOn = dto.BeReadyOn,
            OrderState = OrderStateEnum.Placed,
            OrderProducts = dto.ProductIds.Select(x => new OrderProduct()
            {
                ProductId = x
            }).ToList()
        };

        order.TotalPrice = await _productService.PriceSumAsync(dto.ProductIds);

        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();

        scope.Complete();

        return Result.Success();
    }

    public async Task<Result> CancelOrderAsync(long id)
    {
        var order = await _db.Orders
            .FirstOrDefaultAsync(x => x.Id == id);

        if (order is null || (order.OrderProducts is null && !order.OrderProducts.Any()))
        {
            return Result.NotFound($"Order cannot be found: {MethodBase.GetCurrentMethod().Name}");
        }

        if (order.OrderState == OrderStateEnum.InProgress)
        {
            var errorMessage = (await _errorService.GetById(ErrorConstants.AlreadyInProgress)).Description;
            return Result.Error(errorMessage);
        }

        order.OrderState = OrderStateEnum.Cancelled;

        await _db.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<PagedResult<List<OrderDto>>> GetAllAsync(OrderFilter filter)
    {
        var query = _db.Orders
            .Include(x => x.OrderProducts);

        var orders = await filter.FilterObjects(query).ToListAsync();

        return new PagedResult<List<OrderDto>>(await filter.GetPagedInfoAsync(query), orders.MapToOrdersDtos());
    }

    public async Task<Result<OrderDto>> GetByIdAsync(long id)
    {
        var order = await _db.Orders
            .FirstOrDefaultAsync(x => x.Id == id);

        if(order is null)
        {
            return Result.NotFound();
        }

        return order.MapToOrderDto();
    }

    public async Task<Result> UpdateAsync(UpdateOrderDto dto)
    {
        var order = await _db.Orders
            .Include(x => x.OrderProducts)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if(order is null)
        {
            return Result.NotFound();
        }

        // todo can update some fields like Instruction, OrderTimingType

        TimeSpan elapsedTime = DateTime.UtcNow - order.CreatedDate;
        if (elapsedTime > TimeSpan.FromMinutes(5))
        {
            var errorMessage = (await _errorService.GetById(ErrorConstants.CantUpdateOrder)).Description;
            return Result.Error(errorMessage);
        }

        order.AddressId = dto.AddressId;
        order.BeReadyOn = dto.BeReadyOn;
        order.Instruction = dto.Instruction;
        order.TimingType = dto.OrderTimingType;
        order.OrderState = dto.OrderState;
        order.OrderProducts = dto.ProductIds.Select(x => new OrderProduct()
        {
            ProductId = x
        }).ToList();

        await _db.SaveChangesAsync();
    
        return Result.Success();
    }

    public async Task<Result> UpdateOrderProductsAsync(UpdateOrderProductsDto dto)
    {
        var order = await _db.Orders
            .Include(x => x.OrderProducts)
            .FirstOrDefaultAsync(x => x.Id == dto.OrderId);

        if (order is null || (order.OrderProducts is null && !order.OrderProducts.Any()))
        {
            return Result.NotFound($"Order cannot be found: {MethodBase.GetCurrentMethod().Name}");
        }

        if(order.OrderState == OrderStateEnum.InProgress)
        {
            var errorMessage = (await _errorService.GetById(ErrorConstants.AlreadyInProgress)).Description;
            return Result.Error(errorMessage);
        }

        order.OrderProducts = dto.ProductIds.Select(x => new OrderProduct()
        {
            OrderId = dto.OrderId,
            ProductId = x
        }).ToList();
        await _db.SaveChangesAsync();

        return Result.Success();
    }
}
