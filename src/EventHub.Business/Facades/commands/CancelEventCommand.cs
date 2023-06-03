using EventHub.Entities;

namespace EventHub.Business.Facades;

public sealed class CancelEventCommand : ICommand<Event>
{
    public void Execute(Event @event) => @event.Status = EventStatus.Cancelled;
}  

