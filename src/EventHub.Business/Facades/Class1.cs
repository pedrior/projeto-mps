using EventHub.Entities;

namespace EventHub.Business.Facades
{
    public class StatusLoggerObserver : IEventObserver
    {
        public void OnCancelled(Event ev)
        {
            Console.WriteLine($"O evento {ev.Name} foi cancelado");
        }

        public void OnEnd(Event ev)
        {
            Console.WriteLine($"O evento {ev.Name} foi finalizado");
        }

        public void OnPublish(Event ev)
        {
            Console.WriteLine($"O evento {ev.Name} foi publicado");
        }

        public void OnStart(Event ev)
        {
            Console.WriteLine($"O evento {ev.Name} foi iniciado");
        }
    }
}
