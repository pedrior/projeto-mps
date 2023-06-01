using EventHub.Entities;

namespace EventHub.Business.Facades;

public interface IEventObserver
{
    void OnStart(Event ev);
    
    void OnEnd(Event ev);
    
    void OnPublish(Event ev);
    
    void OnCancelled(Event ev);
}