using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;
using EventHub.Presentation.Views.Account;
using EventHub.Presentation.Views.Events;

namespace EventHub.Presentation.Views;

public sealed class MainView : View
{
    public override string Title => "Welcome to EventHub!";

    protected override Menu BuildMenu()
    {
        return new MenuBuilder()
            .AddMenuItem("Account", GoToAccount)
            .AddMenuItem("Events", GoToEvents)
            .AddMenuItem("Quit", Quit)
            .Build();
    }

    private void GoToAccount() => Navigator.Go(new AccountView(this));
    
    private void GoToEvents() => Navigator.Go(new EventsView(this));

    private static void Quit() => Application.Shutdown();
}