namespace EventHub.Presentation.Views.Internal;

public abstract class NavigationView : View, INavigationView
{
    protected NavigationView(IView ancestor)
    {
        Ancestor = ancestor;
    }

    public IView Ancestor { get; }
}