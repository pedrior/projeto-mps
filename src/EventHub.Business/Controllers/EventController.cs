using EventHub.Business.Exceptions;
using EventHub.Business.Validations;
using EventHub.Entities;
using EventHub.Infrastructure.Persistence.Context;
using EventHub.Infrastructure.Persistence.Repositories;

namespace EventHub.Business.Controllers;

public sealed class EventController
{
    private readonly DbContext dbContext;
    private readonly IEventRepository eventRepository;
    private readonly Validator<Event> eventValidator;

    private readonly EventMementoCaretaker eventMementoCaretaker;

    public EventController()
    {
        dbContext = new DbFactory().GetDefaultContext();
        eventRepository = new EventRepository(dbContext);
        eventValidator = new EventValidator();
        eventMementoCaretaker = new EventMementoCaretaker();
    }

    public void SubscribeToEvent(Event @event, Guid userId)
    {
        if (@event.IsFull())
        {
            throw new EventIsFullException();
        }

        if (@event.Subscriptions.Any(s => s.SubscriberId == userId))
        {
            throw new UserAlreadySubscribedToEventException(
                $"User {userId} already subscribed to event with id: {@event.Id}");
        }

        @event.Subscribe(userId);

        eventRepository.Update(@event);
        dbContext.SaveChanges();
    }

    public void UnsubscribeFromEvent(Event @event, Guid userId)
    {
        if (!@event.Unsubscribe(userId))
        {
            throw new UserSubscriptionNotFoundException($"User {userId} not subscribed to event with id: {@event.Id}");
        }

        eventRepository.Update(@event);
        dbContext.SaveChanges();
    }

    public Event GetEventById(Guid eventId) => eventRepository.FindById(eventId)
                                               ?? throw new EventNotFoundException(
                                                   $"Event not found with id: {eventId}");

    public IEnumerable<Event> GetAllEvents() => eventRepository.GetAll();

    public void AddEvent(Event @event)
    {
        eventValidator.ValidateAndThrow(@event);

        eventRepository.Add(@event);
        dbContext.SaveChanges();
    }

    public void UpdateEvent(Event @event)
    {
        if (!eventRepository.Any(e => e.Id == @event.Id))
        {
            throw new EventNotFoundException($"Event not found with id: {@event.Id}");
        }

        eventValidator.ValidateAndThrow(@event);

        eventRepository.Update(@event);
        dbContext.SaveChanges();
    }

    public void DeleteEventById(Guid eventId)
    {
        var @event = eventRepository.FindById(eventId);
        if (@event is null)
        {
            throw new EventNotFoundException($"Event not found with id: {eventId}");
        }

        // Create a memento of the event before deleting
        var memento = new EventMemento(@event);

        eventRepository.Delete(@event);
        dbContext.SaveChanges();

        // Push the memento onto the undo stack
        eventMementoCaretaker.SaveMemento(memento);
    }

    public void UndoDelete()
    {
        var state = eventMementoCaretaker.RestoreMemento();
        if (state is null)
        {
            throw new UndoNotSupportedException("No state to restore");
        }
        
        eventRepository.Add(state.Restore());
    }
}