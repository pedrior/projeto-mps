using EventHub.Business.Facades;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Account;

public sealed class LoginView : NavigationView
{
    private readonly UserFacade userFacade = UserFacade.Current;

    public LoginView(IView ancestor) : base(ancestor)
    {
    }

    public override string Title => "Account - Login";

    protected override Menu BuildMenu()
    {
        return new MenuBuilder()
            .AddMenuItem("Back", GoBack)
            .Build();
    }

    protected override void BuildContent()
    {
        var email = ConsoleHelper.ReadRequiredString("Email");
        var password = ConsoleHelper.ReadRequiredString("Password");

        if (userFacade.Login(email, password))
        {
            GoBack();
        }
        else
        {
            if (ConsoleHelper.ReadYesNo("\nLogin failed! Do you want to try again?"))
            {
                Reshow();
            }
            else
            {
                GoBack();
            }
        }
    }

    private void GoBack() => Navigator.Back(this, invalidateAncestorMenu: true);
}