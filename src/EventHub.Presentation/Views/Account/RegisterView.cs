using EventHub.Business.Facades;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Account;

public sealed class RegisterView : NavigationView
{
    private readonly UserFacade userFacade = UserFacade.Current;

    public RegisterView(IView ancestor) : base(ancestor)
    {
    }

    public override string Title => "Account - Register";

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
        var firstName = ConsoleHelper.ReadRequiredString("First name");
        var lastName = ConsoleHelper.ReadRequiredString("Last name");

        var (succeeded, message) = userFacade.Register(email, password, firstName, lastName);
        if (succeeded)
        {
            GoBack();
        }
        else
        {
            Console.Write($"\r{message}\n");
            if (ConsoleHelper.ReadYesNo("\nRegistration failed! Do you want to try again?"))
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