using Microsoft.AspNetCore.SignalR;

namespace Waitless.BLL;

public class NotificationHub : Hub
{
    public async Task SendNotification(string message)
    {
        await Clients.Caller.SendAsync("Ping", "Pong");
    }
}