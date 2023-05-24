using EventHub.Business.Controllers;
using EventHub.Presentation.Views.Controls;
using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation.Views;

public sealed class MainView : View
{
    private readonly UserController userController = new();
    private readonly MenuBuilder menuBuilder = new();

    public override string Title => "Welcome to EventHub!";

    protected override Menu CreateMenu()
    {
        return menuBuilder
            .AddMenuItem("Sign in", GoToSignInView)
            .AddMenuItem("Sign up", GoToSignUpView)
            .AddMenuItem("List users", GoToUserListView)
            .AddMenuItem("Statistics", GoToStatisticsView)
            .AddMenuItem("Exit", Exit)
            .Build();
    }

    private void GoToSignInView() => Navigator.Go(new SignInView(this, userController));

    private void GoToSignUpView() => Navigator.Go(new SignUpView(this, userController));

    private void GoToUserListView() => Navigator.Go(new UserListView(this, userController));
    
    private void GoToStatisticsView() => Navigator.Go(new StatisticsView(this, userController));

    private static void Exit() => Application.Shutdown();
}