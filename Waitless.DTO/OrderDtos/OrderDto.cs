﻿using Waitless.DAL.Enums;
using Waitless.DAL.Models;
using System.Collections.ObjectModel;

namespace Waitless.DTO.OrderDtos;

public class OrderDto : BaseEntity
{
    public OrderDto()
    {
        Products = new HashSet<Product>();
    }
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public string Instruction { get; set; }
    public OrderTimingType? TimingType { get; set; }
    public DateTime? BeReadyOn { get; set; }
    public bool IsReady { get; set; }
    public decimal? TotalPrice{ get; set; }

    public ICollection<Product> Products { get; set; }
}
