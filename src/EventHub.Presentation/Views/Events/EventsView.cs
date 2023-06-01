using EventHub.Business.Facades;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Events;

public sealed class EventsView : NavigationView
{
    public EventsView(IView ancestor) : base(ancestor)
    {
    }

    public override string Title => "Events";
    
    protected override Menu BuildMenu()
    {
        var menu = new MenuBuilder()
            .AddMenuItem("All Events", GoToAllEvents)
            .AddMenuItem("Go back", GoBack);

        if (IsUserAuthenticated())
        {
            menu.AddMenuItem("My Events", GoToMyEvents, position:1)
                .AddMenuItem("Create Event", GoToCreateEvent, position:2);
        }

        return menu.Build();
    }

    private void GoToAllEvents() => Navigator.Go(new AllEventsView(this));

    private void GoToMyEvents() => Navigator.Go(new MyEventsView(this));

    private void GoToCreateEvent() => Navigator.Go(new CreateEventView(this));

    private void GoBack() => Navigator.Back(this);
    
    private static bool IsUserAuthenticated() => UserFacade.Current.IsLoggedIn;
}