namespace Waitless.DAL.Models;

public class MerchantPasswordReset : BaseEntity
{
        public long MerchantId { get; set; }
        public string Token { get; set; }
        public bool Expired { get; set; } = false;

        public Merchant Merchant { get; set; }
}