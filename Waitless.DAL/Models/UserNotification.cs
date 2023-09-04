namespace Waitless.DAL.Models;

public class UserNotification : BaseEntity
{
    public long UserId { get; set; }
    public long NotificationId { get; set; }

    public User User { get; set; }
    public Notification Notification { get; set; }
}