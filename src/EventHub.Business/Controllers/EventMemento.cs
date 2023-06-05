using EventHub.Entities;

namespace EventHub.Business.Controllers;

internal sealed class EventMemento
{
    private readonly Event snapshot;

    public EventMemento(Event @event)
    {
        snapshot = new Event
        {
            Id = @event.Id,
            OwnerId = @event.OwnerId,
            CategoryId = @event.CategoryId,
            Name = @event.Name,
            Description = @event.Description,
            StartDate = @event.StartDate,
            EndDate = @event.EndDate,
            Capacity = @event.Capacity,
        };
    }

    public Event Restore() => snapshot;
}