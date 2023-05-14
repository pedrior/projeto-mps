using EventHub.Entities;
using EventHub.Infrastructure.Services.Notification;

namespace EventHub.Business.Controllers.Notifications;

public sealed class EventUnsubscribedNotification : INotification
{
    private readonly Event @event;
    private readonly User user;

    public EventUnsubscribedNotification(Event @event, User user)
    {
        this.@event = @event;
        this.user = user;
    }

    public string Recipient => user.FullName;

    public string CreateMessage() => $"{user.FullName} has unsubscribed from event {@event.Name}";
}