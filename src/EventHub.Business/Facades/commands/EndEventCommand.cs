using EventHub.Entities;

namespace EventHub.Business.Facades.commands;

public sealed class EndEventCommand : ICommand<Event>
{
    public void Execute(Event @event) => @event.Status = EventStatus.Ended;
}

