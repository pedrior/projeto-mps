using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;
using EventHub.Presentation.Views.Account;

namespace EventHub.Presentation.Views;

public sealed class MainView : View
{
    private readonly MenuBuilder menuBuilder = new();

    public override string Title => "Welcome to EventHub!";

    protected override Menu BuildMenu()
    {
        return menuBuilder
            .AddMenuItem("Account", GoToAccount)
            .AddMenuItem("Quit", Quit)
            .Build();
    }

    private void GoToAccount() => Navigator.Go(new AccountView(this));

    private static void Quit() => Application.Shutdown();
}