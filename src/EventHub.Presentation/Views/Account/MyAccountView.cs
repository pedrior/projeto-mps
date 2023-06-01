using EventHub.Business.Facades;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Account;

public sealed class MyAccountView : NavigationView
{
    private readonly UserFacade userFacade = UserFacade.Current;
    
    public MyAccountView(IView ancestor) : base(ancestor)
    {
    }

    public override string Title => "Account - My Account";
    
    protected override Menu BuildMenu()
    {
        return new MenuBuilder()
            .AddMenuItem("Back", GoBack)
            .Build();
    }

    protected override void BuildContent()
    {
        Console.WriteLine(userFacade.GetCurrentUser());
    }

    private void GoBack() => Navigator.Back(this);
}