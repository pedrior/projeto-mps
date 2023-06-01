namespace EventHub.Presentation.Common.Views;

public interface INavigationView : IView
{
    IView Ancestor { get; }
}