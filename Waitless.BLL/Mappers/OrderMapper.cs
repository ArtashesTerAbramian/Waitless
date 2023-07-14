using Waitless.DAL.Models;
using Waitless.DTO.OrderDtos;
using Riok.Mapperly.Abstractions;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class OrderMapper
{
    public static partial OrderDto MapToOrderDto(this Order order);
    public static partial List<OrderDto> MapToOrdersDtos(this List<Order> orders);
}