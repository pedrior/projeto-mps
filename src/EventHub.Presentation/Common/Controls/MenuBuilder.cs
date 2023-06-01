namespace EventHub.Presentation.Common.Controls;

public sealed class MenuBuilder
{
    private readonly Menu menu = new();

    public MenuBuilder AddMenuItem(string title, Action action, int? position = null)
    {
        menu.AddMenuItem(MenuItem.Create(title, action), position);
        return this;
    }
    
    public MenuBuilder AddSeparator(int? position = null)
    {
        menu.AddSeparator(position);
        return this;
    }
    
    public Menu Build() => menu;
}