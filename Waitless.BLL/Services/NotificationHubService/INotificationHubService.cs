using Waitless.DTO.NotificationDtos;

namespace Waitless.BLL.Services.NotificationHubService;

public interface INotificationHubService
{
    Task NotificationAdd(List<long> clientIds, NotificationDto notificationDto);
}