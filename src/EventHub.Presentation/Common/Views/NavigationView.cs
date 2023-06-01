namespace EventHub.Presentation.Common.Views;

public abstract class NavigationView : View, INavigationView
{
    protected NavigationView(IView ancestor)
    {
        Ancestor = ancestor;
    }

    public IView Ancestor { get; }
}