using EventHub.Entities;

namespace EventHub.Business.Facades;

public sealed class StartEventCommand : ICommand<Event>
{
    public void Execute(Event @event) => @event.Status = EventStatus.Started;
}