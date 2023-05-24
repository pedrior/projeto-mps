using EventHub.Business.Controllers;
using EventHub.Business.Exceptions;
using EventHub.Presentation.Views.Controls;
using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation.Views;

public sealed class SignInView : NavigationView
{
    private readonly MenuBuilder menuBuilder = new();
    private readonly UserController userController;
    
    public SignInView(IView ancestor, UserController userController) : base(ancestor)
    {
        this.userController = userController;
    }
    
    public override string Title => "Sign in";
    
    protected override void CreateContent()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? string.Empty;
        Console.Write("Password: ");
        var password = Console.ReadLine() ?? string.Empty;

        Guid userId;
        try
        {
            userId = userController.SignIn(email, password);
        }
        catch (AuthenticationException ae)
        {
            Console.WriteLine(ae);
            return;
        }
        
        var user = userController.GetUserById(userId);
        Console.WriteLine($"Welcome, {user.FirstName} {user.LastName}!");
    }
    
    protected override Menu CreateMenu()
    {
        return menuBuilder
            .AddMenuItem("Back", GoBack)
            .Build();
    }

    private void GoBack() => Navigator.Back(this);
}