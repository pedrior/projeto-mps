using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Common;

public static class Navigator
{
    public static void Go(INavigationView view)
    {
        Console.Clear();

        view.Show();
    }
    
    public static void Back(INavigationView view, bool invalidateAncestorMenu = false)
    {
        Console.Clear();
        
        if (invalidateAncestorMenu)
        {
            view.Ancestor.InvalidateMenu();
        }
        
        view.Ancestor.Show();
    }
}