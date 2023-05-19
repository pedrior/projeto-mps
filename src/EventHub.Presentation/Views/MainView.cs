using EventHub.Presentation.Views.Controls;
using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation.Views;

public sealed class MainView : View
{
    private readonly MenuBuilder menuBuilder = new();

    public override string Title => "Welcome to EventHub!";

    protected override Menu CreateMenu()
    {
        return menuBuilder
            .AddMenuItem("Sign in", GoToSignInView)
            .AddMenuItem("Sign up", GoToSignUpView)
            .AddMenuItem("List users", GoToUserListView)
            .AddMenuItem("Exit", Exit)
            .Build();
    }

    private void GoToSignInView() => Navigator.Go(new SignInView(this));

    private void GoToSignUpView() => Navigator.Go(new SignUpView(this));

    private void GoToUserListView() => Navigator.Go(new UserListView(this));

    private static void Exit() => Application.Shutdown();
}