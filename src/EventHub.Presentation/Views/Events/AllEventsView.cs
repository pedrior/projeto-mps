using EventHub.Business.Facades;
using EventHub.Entities;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Events;

public sealed class AllEventsView : NavigationView
{
    private readonly EventFacade eventFacade = EventFacade.Current;

    private readonly List<Event> events;

    public AllEventsView(IView ancestor) : base(ancestor)
    {
        events = new List<Event>(eventFacade.GetAllEvents());
    }

    public override string Title => "Events – All Events";
    
    protected override Menu BuildMenu()
    {
        var menu = new MenuBuilder()
            .AddMenuItem("Go back", GoBack)
            .AddSeparator();
        
        events.ForEach(e => menu.AddMenuItem(e.Name, () => GoToEventDetails(e)));
        
        return menu.Build();
    }

    private void GoToEventDetails(Event @event) => Navigator.Go(new EventDetailsView(this, @event));

    private void GoBack() => Navigator.Back(this);
}