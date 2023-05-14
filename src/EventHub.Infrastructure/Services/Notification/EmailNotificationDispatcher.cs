namespace EventHub.Infrastructure.Services.Notification;

internal sealed class EmailNotificationDispatcher : INotificationDispatcher
{
    public void Dispatch(INotification notification)
    {
        Console.WriteLine($"Sending email to {notification.Recipient}...");
        Console.WriteLine(notification.CreateMessage());
    }
}