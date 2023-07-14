using Waitless.DAL.Enums;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace Waitless.DAL.Models;

public class Order : BaseEntity
{
    public Order()
    {
        CoffeeIds = new HashSet<long>();
    }
    
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public string Instruction { get; set; }
    public OrderTimingType? TimingType { get; set; }
    public DateTime? BeReadyOn { get; set; }
    public bool IsReady { get; set; } = false;
    
    public decimal TotalPrice
    {
        get { return _total; }
        private set { _total = value; }
    }
    
    private decimal _total;
    
    // todo to be changed (adding orderId column to coffe table)
    [NotMapped]
    public ICollection<long> CoffeeIds { get; set; }

    User User { get; set; }
    Address Address { get; set; }
}
