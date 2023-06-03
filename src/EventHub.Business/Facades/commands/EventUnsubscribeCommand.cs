using EventHub.Business.Controllers;
using EventHub.Entities;

namespace EventHub.Business.Facades;

public sealed class EventUnsubscribeCommand : ICommand<Event>
{
    private readonly EventController eventController;
    private readonly User user;

    public EventUnsubscribeCommand(EventController eventController, User user)
    {
        this.eventController = eventController;
        this.user = user;
    }

    public void Execute(Event @event) => eventController.UnsubscribeFromEvent(@event, user.Id);
}