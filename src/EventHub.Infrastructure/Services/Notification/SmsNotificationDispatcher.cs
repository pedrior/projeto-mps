namespace EventHub.Infrastructure.Services.Notification;

internal sealed class SmsNotificationDispatcher : INotificationDispatcher
{
    public void Dispatch(INotification notification)
    {
        Console.WriteLine($"Sending SMS to {notification.Recipient}...");
        Console.WriteLine(notification.CreateMessage());
    }
}