namespace EventHub.Infrastructure.Services.Notification;

public sealed class NotificationDispatcherFactory : INotificationDispatcherFactory
{
    public INotificationDispatcher CreateNotificationDispatcher(NotificationType type) => type switch
    {
        NotificationType.Email => new EmailNotificationDispatcher(),
        NotificationType.Sms => new SmsNotificationDispatcher(),
        NotificationType.Push => new PushNotificationDispatcher(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
}