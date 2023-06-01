using EventHub.Business.Facades;
using EventHub.Presentation.Common;
using EventHub.Presentation.Common.Controls;
using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Views.Account;

public sealed class AccountView : NavigationView
{
    private readonly UserFacade userFacade;

    public AccountView(IView ancestor) : base(ancestor)
    {
        userFacade = UserFacade.Current;
    }

    public override string Title => "Account";

    protected override Menu BuildMenu()
    {
        var builder = new MenuBuilder()
            .AddMenuItem("Generate statistics (HTML)", GenerateStatisticsInHtml)
            .AddMenuItem("Generate statistics (PDF)", GenerateStatisticsInPdf)
            .AddMenuItem("Back", GoBack);

        if (userFacade.IsLoggedIn)
        {
            builder
                .AddMenuItem("My Account", GoMyAccount, position: 0)
                .AddMenuItem("Logout", GoLogout, position: 1)
                .AddMenuItem("Delete", GoDelete, position: 2);
        }
        else
        {
            builder
                .AddMenuItem("Login", GoLogin, position: 0)
                .AddMenuItem("Register", GoRegister, position: 1);
        }

        return builder.Build();
    }

    private void GoMyAccount() => Navigator.Go(new MyAccountView(this));

    private void GoLogin() => Navigator.Go(new LoginView(this));

    private void GoLogout()
    {
        userFacade.Logout();
        Reshow();
    }

    private void GoRegister() => Navigator.Go(new RegisterView(this));

    private void GoDelete()
    {
         userFacade.DeleteLoggedUser();
         Reshow();
    }

    private void GoBack() => Navigator.Back(this);

    private void GenerateStatisticsInHtml() => GenerateStatistics(userFacade.GenerateHtmlUserStatisticsReport);
    private void GenerateStatisticsInPdf() => GenerateStatistics(userFacade.GeneratePdfUserStatisticsReport);

    private void GenerateStatistics(Action generator)
    {
        Console.WriteLine("\nGenerating statistics...");

        generator();

        Console.ForegroundColor = ConsoleColor.Green;

        for (var i = 2; i > 0; i--)
        {
            Console.Write($"\rStatistics generated successfully! {i}");
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        Console.ResetColor();
        
        Reshow();
    }
}