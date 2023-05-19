namespace EventHub.Presentation.Views.Controls;

public sealed class MenuBuilder
{
    private readonly Menu menu = new();

    public MenuBuilder AddMenuItem(string title, Action action)
    {
        var item = new MenuItem
        {
            Title = title,
            Action = action
        };
        
        menu.AddMenuItem(item);
        return this;
    }
    
    public Menu Build() => menu;
}