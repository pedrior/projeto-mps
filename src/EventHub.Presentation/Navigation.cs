using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation;

public static class Navigator
{
    public static void Go(INavigationView view)
    {
        Console.Clear();
        view.Show();
    }

    public static void Back(INavigationView view)
    {
        Console.Clear();
        view.Ancestor.Show();
    }
}