namespace Waitless.DAL.Models;

public class MerchantSession : BaseEntity
{
    
    public long MerchantId { get; set; }
    public string Token { get; set; }
    public bool IsExpired { get; set; }

    public Merchant Merchant { get; set; }
}