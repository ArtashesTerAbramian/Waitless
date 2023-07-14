namespace Waitless.DAL.Models;

public class UserSession : BaseEntity
{
    public long UserId { get; set; }
    public string Token { get; set; }
    public bool IsExpired { get; set; }

    public User User { get; set; }
}
