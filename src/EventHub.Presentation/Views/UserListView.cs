using EventHub.Business.Controllers;
using EventHub.Presentation.Views.Controls;
using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation.Views;

public sealed class UserListView : NavigationView
{
    private readonly MenuBuilder menuBuilder = new();
    private readonly UserController userController;
    
    public UserListView(IView ancestor, UserController userController) : base(ancestor)
    {
        this.userController = userController;
    }

    public override string Title => "Users";
    
    protected override Menu CreateMenu()
    {
        return menuBuilder
            .AddMenuItem("Back", GoBack)
            .Build();
    }

    protected override void CreateContent()
    {
        foreach (var user in userController.GetAllUsers())
        {
            Console.WriteLine(user);
        }
    }

    private void GoBack() => Navigator.Back(this);
}