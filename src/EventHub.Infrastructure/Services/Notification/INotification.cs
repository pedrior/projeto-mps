
namespace EventHub.Infrastructure.Services.Notification;

public interface INotification
{
    string Recipient { get; }

    string CreateMessage();
}