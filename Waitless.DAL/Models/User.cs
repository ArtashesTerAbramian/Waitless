namespace Waitless.DAL.Models;

public class User : BaseEntity
{
    public User()
    {
        UserSessions = new HashSet<UserSession>();
    }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public ICollection<UserSession> UserSessions { get; set; }
}