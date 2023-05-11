namespace EventHub.Business.Entities.Events;

using EventHub.Business.Entities.Users;
using EventHub.Core.Entities;
using EventHub.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
public sealed record EventId
{
    private EventId(Guid value) => Value = value;

    public Guid Value { get; }

    public static EventId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}

 public class EventSubscriptionRepository : Entity<EventSubscription>
{
    private const string FilePath = "eventIds.txt";

    public void Add(Events events,EventId id)
    {
         id = EventId.New();
        var event = GetAllCategories();
        event.Add(events);
        SaveCategoriesToFile(event);
    }

    public void Update(EventId id)
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

    public EventId GetById(EventId id)
    {
        var event = GetAllCategories();
        return event.Find(c => c.Id == id) ?? throw new InvalidOperationException("Category not found.");
    }

    public List<EventId> GetAll()
    {
        return GetAllCategories();
    }

    private List<EventId> GetAllCategories()
    {
        if (!File.Exists(FilePath))
        {
            return new List<EventId>();
        }

        var event = new List<EventId>();
        using (var reader = new StreamReader(FilePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var eventData = line.Split(';');
                if (eventData.Length >= 3)
                {
                    var events = new Event
                    {
                        Id = new EventId(eventData[0])
                    };
                    event.Add(events);
                }
            }
        }

        return event;
    }

    private void SaveCategoriesToFile(List<EventId> eventId)
    {
        using (var writer = new StreamWriter(FilePath))
        {
            foreach (var event in events)
            {
                writer.WriteLine($"{event.Id};{event.Name};{event.Description}");
            }
        }
    }

    public static void Add(EventId eventId)
    {
        throw new NotImplementedException();
    }

    public static object GetById(object id)
    {
        throw new NotImplementedException();
    }
}  
