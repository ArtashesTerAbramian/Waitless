using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using System.Collections.ObjectModel;

namespace Waitless.DTO.OrderDtos;

public class UpdateOrderDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public List<long> ProductIds { get; set; }
    public string? Instruction { get; set; }
    public OrderTimingType? OrderTimingType { get; set; }
    public DateTime? BeReadyOn { get; set; }
    public OrderStateEnum OrderState { get; set; }
}
