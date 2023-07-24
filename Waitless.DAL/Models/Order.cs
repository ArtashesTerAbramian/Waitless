using Waitless.DAL.Enums;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace Waitless.DAL.Models;

public class Order : BaseEntity
{
    public Order()
    {
        OrderProducts = new HashSet<OrderProduct>();
    }

    public long UserId { get; set; }
    public long VendorId { get; set; }
    public long AddressId { get; set; }
    public string Instruction { get; set; }
    public OrderStateEnum OrderState { get; set; }
    public OrderTimingType? TimingType { get; set; }
    public DateTime? BeReadyOn { get; set; }
    public bool IsReady { get; set; } = false;

    public decimal TotalPrice { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }

    Vendor Vendor { get; set; }
    User User { get; set; }
    Address Address { get; set; }

    public override bool Equals(object obj)
    {
        var order = obj as Order;

        return UserId == order.UserId
            && AddressId == order.AddressId
            && Instruction == order.Instruction
            && TimingType == order.TimingType
            && BeReadyOn == order.BeReadyOn
            && IsReady == order.IsReady
            && OrderProducts.SequenceEqual(order.OrderProducts);
    }
}
