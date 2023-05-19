using EventHub.Business.Controllers;
using EventHub.Presentation.Views.Controls;
using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation.Views;

public sealed class UserListView : NavigationView
{
    private readonly UserController userController = new();
    private readonly MenuBuilder menuBuilder = new();
    
    public UserListView(IView ancestor) : base(ancestor)
    {
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