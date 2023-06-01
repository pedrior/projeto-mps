namespace EventHub.Presentation.Common.Controls;

public sealed class MenuItem
{
    public required string Title { get; init; }
    
    public required Action Action { get; init; }
}