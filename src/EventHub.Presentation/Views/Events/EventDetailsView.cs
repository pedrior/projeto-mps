using EventHub.Business.Facades;
using EventHub.Entities;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Events;

public sealed class EventDetailsView : NavigationView
{
    private readonly EventFacade eventFacade = EventFacade.Current;
    private readonly UserFacade userFacade = UserFacade.Current;
    private readonly Event @event;

    public EventDetailsView(IView ancestor, Event @event) : base(ancestor)
    {
        this.@event = @event;
    }

    public override string Title => $"Events – {@event.Name}";

    protected override void BuildContent() => Console.WriteLine(@event.ToString());

    protected override Menu BuildMenu()
    {
        var menu = new MenuBuilder()
            .AddMenuItem("Go back", GoBack)
            .AddSeparator();

        if (!IsUserAuthenticated())
        {
            return menu.Build();
        }

        if (IsEventOwnedByCurrentUser)
        {
            menu.AddMenuItem("Edit", GoToEditEvent)
                .AddMenuItem("Delete", DeleteEvent);

            return menu.Build();
        }

        if (!eventFacade.IsUserSubscribed(@event, userFacade.GetCurrentUser()!))
        {
            menu.AddMenuItem("Register", SubscribeToEvent);
        }
        else
        {
            menu.AddMenuItem("Unregister", UnregisterFromEvent);
        }

        return menu.Build();
    }

    private void GoToEditEvent() => Navigator.Go(new EditEventView(this, @event));

    private void DeleteEvent()
    {
        eventFacade.DeleteEvent(@event);
        Navigator.Back(this);
    }

    private void UnregisterFromEvent()
    {
        eventFacade.Unsubscribe(@event, userFacade.GetCurrentUser()!);
        Reshow();
    }

    private void SubscribeToEvent()
    {
        eventFacade.Subscribe(@event, userFacade.GetCurrentUser()!);
        Reshow();
    }

    private void GoBack() => Navigator.Back(this);

    private static bool IsUserAuthenticated() => UserFacade.Current.IsLoggedIn;

    private bool IsEventOwnedByCurrentUser => @event.OwnerId == UserFacade.Current.GetCurrentUser()?.Id;
}