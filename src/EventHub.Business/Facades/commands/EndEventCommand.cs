using EventHub.Entities;

namespace EventHub.Business.Facades;

public sealed class EndEventCommand : ICommand<Event>
{
    public void Execute(Event @event) => @event.Status = EventStatus.Ended;
}

