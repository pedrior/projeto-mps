namespace EventHub.Entities;

public sealed class EventSubscription
{
    public required Guid EventId { get; init; }

    public required Guid SubscriberId { get; init; }

    public DateTimeOffset SubscribedAt { get; } = DateTimeOffset.UtcNow;
}
