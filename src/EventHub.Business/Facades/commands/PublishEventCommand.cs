using EventHub.Entities;

namespace EventHub.Business.Facades;

public sealed class PublishEventCommand : ICommand<Event>
{
    public void Execute(Event @event) => @event.Status = EventStatus.Published;
}