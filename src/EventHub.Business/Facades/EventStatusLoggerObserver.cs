using EventHub.Entities;

namespace EventHub.Business.Facades;

public class EventStatusLoggerObserver : IEventObserver
{
    public void OnCancelled(Event ev) => Console.WriteLine($"Event '{ev.Name}' has been cancelled.");

    public void OnEnd(Event ev) => Console.WriteLine($"Event '{ev.Name}' has been ended.");

    public void OnPublish(Event ev) => Console.WriteLine($"Event '{ev.Name}' has been published.");

    public void OnStart(Event ev) => Console.WriteLine($"Event '{ev.Name}' has been started.");
}