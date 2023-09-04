using Microsoft.AspNetCore.SignalR;
using Waitless.DTO.NotificationDtos;

namespace Waitless.BLL.Services.NotificationHubService;

public class NotificationHubService : INotificationHubService
{
    private readonly IHubContext<NotificationHub> _hub;

    public NotificationHubService(IHubContext<NotificationHub> hub)
    {
        _hub = hub;
    }
    
    public async Task NotificationAdd(List<long> clientIds, NotificationDto notificationDto)
    {
        await SendNotification("ReceiveNotification", notificationDto, clientIds);
    }

    private async Task SendNotification<T>(string method, T data)
    {
        await _hub.Clients.All.SendAsync(method, data);
    }

    private async Task SendNotification<T>(string method, T data, long clientId)
    {
        await _hub.Clients.User(clientId.ToString()).SendAsync(method, data);
    }

    private async Task SendNotification<T>(string method, T data, List<long> clientIds)
    {
        await _hub.Clients.Users(clientIds.Distinct().Select(x => x.ToString()).ToList()).SendAsync(method, data);
    }
}