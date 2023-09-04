using Microsoft.AspNetCore.SignalR;

namespace Waitless.BLL.Services.NotificationService;

public class NotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hub;

    public NotificationService(IHubContext<NotificationHub> _notificationHub)
    {
        this._hub = _notificationHub;
    }
}