namespace EventHub.Infrastructure.Services.Notification;

internal sealed class PushNotificationDispatcher : INotificationDispatcher
{
    public void Dispatch(INotification notification)
    {
        Console.WriteLine($"Sending push notification to {notification.Recipient}...");
        Console.WriteLine(notification.CreateMessage());
    }
}