namespace Waitless.DAL.Models;

public class Notification : BaseEntity
{
    public Notification()
    {
        UserNotifications = new HashSet<UserNotification>();
    }

    public long? NotificationCreatorMerchantId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public DateTime? PublishDate { get; set; }

    public Merchant NotificationCreatorMerchant { get; set; }
    public ICollection<UserNotification> UserNotifications { get; set; }
}