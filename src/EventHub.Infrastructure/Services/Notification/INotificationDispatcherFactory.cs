namespace EventHub.Infrastructure.Services.Notification;

public interface INotificationDispatcherFactory
{
    INotificationDispatcher CreateNotificationDispatcher(NotificationType type);
}