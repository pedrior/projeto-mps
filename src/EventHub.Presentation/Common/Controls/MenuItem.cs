namespace EventHub.Presentation.Common.Controls;

public sealed class MenuItem
{
    private MenuItem()
    {
    }

    public string Title { get; init; } = null!;
    
    public bool IsSeparator { get; init; }

    public Action Action { get; init; } = null!;
    
    public static MenuItem Separator() => new() { IsSeparator = true };
    
    public static MenuItem Create(string title, Action action) => new()
    {
        Title = title,
        Action = action
    };
}