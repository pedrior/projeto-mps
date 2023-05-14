namespace EventHub.Infrastructure.Services.Notification;

public interface INotificationDispatcher
{
    void Dispatch(INotification notification);
}