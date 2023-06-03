using EventHub.Business.Controllers;
using EventHub.Entities;

namespace EventHub.Business.Facades;

public sealed class EventSubscribeCommand : ICommand<Event>
{
    private readonly EventController eventController;
    private readonly User user;

    public EventSubscribeCommand(EventController eventController, User user)
    {
        this.eventController = eventController;
        this.user = user;
    }

    public void Execute(Event @event) => eventController.SubscribeToEvent(@event, user.Id);
}