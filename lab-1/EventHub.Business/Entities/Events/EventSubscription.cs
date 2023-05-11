using EventHub.Business.Entities.Users;
using EventHub.Core.Entities;

namespace EventHub.Business.Entities.Events;

public sealed class EventSubscription : Entity
{
    public required EventId EventId { get; init; }

    public required UserId UserId { get; init; }

    public required DateTimeOffset SubscriptionDate { get; init; }
}


public class EventSubscriptionRepository : Entity<EventSubscription>
{
    private const string FilePath = "eventsSubscription.txt";

    public void Add(EventSubscription eventSubscription, EventId id)
    {
        id = EventId.New();
        var event = GetAllCategories();
        event.Add(eventSubscription);
        SaveCategoriesToFile(eventSubscription);
    }

    public void Update(EventSubscription eventSubscription)
    {
        var event = GetAllCategories();
        var existingEvent = event.Find(c => c.Id == event.Id);
        if (existingEvent != null)
        {
            existingEvent.Name = event.Name;
            existingEvent.Description = event.Description;
            SaveCategoriesToFile(event);
        }
    }

    public void Delete(EventId id)
    {
        var event = GetAllCategories();
        var eventToRemove = event.Find(c => c.Id == id);
        if (eventToRemove != null)
        {
            event.Remove(eventToRemove);
            SaveCategoriesToFile(eventToRemove);
        }
    }

    public Category GetById(EventId id)
    {
        var event = GetAllCategories();
        return event.Find(c => c.Id == id) ?? throw new InvalidOperationException("Category not found.");
    }

    public List<EventSubscription> GetAll()
    {
        return GetAllCategories();
    }

    private List<EventSubscription> GetAllCategories()
    {
        if (!File.Exists(FilePath))
        {
            return new List<EventSubscription>();
        }

        var event = new List<EventSubscription>();
        using (var reader = new StreamReader(FilePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var eventData = line.Split(';');
                if (eventData.Length >= 3)
                {
                    var events = new EventSubscription
                    {
                        Id = new EventId(eventData[0]),
                        Name = eventData[1],
                        Description = eventData[2]
                    };
                    event.Add(category);
                }
            }
        }

        return event;
    }

    private void SaveCategoriesToFile(List<EventSubscription> eventSubscription)
    {
        using (var writer = new StreamWriter(FilePath))
        {
            foreach (var event in events)
            {
                writer.WriteLine($"{event.Id};{event.Name};{event.Description}");
            }
        }
    }

    public static void Add(EventSubscription eventSubscription)
    {
        throw new NotImplementedException();
    }

    public static object GetById(object id)
    {
        throw new NotImplementedException();
    }
}  