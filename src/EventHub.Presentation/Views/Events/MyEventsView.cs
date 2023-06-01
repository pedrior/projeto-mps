using EventHub.Business.Facades;
using EventHub.Entities;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Events;

public sealed class MyEventsView : NavigationView
{
    private readonly EventFacade eventFacade = EventFacade.Current;
    private readonly UserFacade userFacade = UserFacade.Current;

    private readonly List<Event> events;

    public MyEventsView(IView ancestor) : base(ancestor)
    {
        events = new List<Event>(eventFacade.GetAllEvents()
            .Where(e => e.OwnerId == userFacade.GetCurrentUser()!.Id));
    }

    public override string Title => "Events – My Events";

    protected override void BuildContent()
    {
        if (events.Count is 0)
        {
            Console.WriteLine("You have no events.");
        }
        
        foreach (var @event in events)
        {
            Console.WriteLine(@event.ToString());
        }
    }

    protected override Menu BuildMenu()
    {
        var menu = new MenuBuilder()
            .AddMenuItem("Go back", GoBack)
            .AddSeparator();

        events.ForEach(e => menu.AddMenuItem(e.Name, () => GoToEventDetails(e)));

        return menu.Build();
    }

    private void GoBack() => Navigator.Back(this);

    private void GoToEventDetails(Event @event) => Navigator.Go(new EventDetailsView(this, @event));
}