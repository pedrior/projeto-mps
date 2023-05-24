using EventHub.Business.Controllers;
using EventHub.Business.Validations;
using EventHub.Entities;
using EventHub.Presentation.Views.Controls;
using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation.Views;

public sealed class SignUpView : NavigationView
{
    private readonly MenuBuilder menuBuilder = new();
    private readonly UserController userController;
    
    public SignUpView(IView ancestor, UserController userController) : base(ancestor)
    {
        this.userController = userController;
    }

    public override string Title => "Sign up";

    protected override void CreateContent()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? string.Empty;
        Console.Write("Password: ");
        var password = Console.ReadLine() ?? string.Empty;
        Console.Write("First name: ");
        var firstName = Console.ReadLine() ?? string.Empty;
        Console.Write("Last name: ");
        var lastName = Console.ReadLine() ?? string.Empty;

        var user = new BasicUser
        {
            Email = email,
            Password = password,
            FirstName = firstName,
            LastName = lastName
        };

        try
        {
            userController.AddBasicUser(user);
        }
        catch (ValidationException ve)
        {
            Console.WriteLine(ve.Message);
        }
    }
    
    protected override Menu CreateMenu()
    {
        return menuBuilder
            .AddMenuItem("Back", GoBack)
            .Build();
    }

    private void GoBack() => Navigator.Back(this);
}