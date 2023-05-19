namespace EventHub.Presentation.Views.Internal;

public interface INavigationView : IView
{
    IView Ancestor { get; }
}