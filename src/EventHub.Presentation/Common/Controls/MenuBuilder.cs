namespace EventHub.Presentation.Common.Controls;

public sealed class MenuBuilder
{
    private readonly Menu menu = new();

    public MenuBuilder AddMenuItem(string title, Action action, int? position = null)
    {
        var item = new MenuItem
        {
            Title = title,
            Action = action
        };
        
        menu.AddMenuItem(item, position);
        return this;
    }
    
    public Menu Build() => menu;
}