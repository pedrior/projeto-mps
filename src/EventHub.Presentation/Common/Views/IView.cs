namespace EventHub.Presentation.Common.Views;

public interface IView
{
    string Title { get;}

    void Show();
    
    void InvalidateMenu();
}