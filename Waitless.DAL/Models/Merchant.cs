namespace Waitless.DAL.Models;

public class Merchant : BaseEntity
{
    public Merchant()
    {
        MerchantSessions = new HashSet<MerchantSession>();
    }
    
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string ActivationToken { get; set; }
    public bool IsActive { get; set; }
    public long? RoleId { get; set; }

    public Role Role { get; set; }
    
    public ICollection<MerchantSession> MerchantSessions { get; set; }
}