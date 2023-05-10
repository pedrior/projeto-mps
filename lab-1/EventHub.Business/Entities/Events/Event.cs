using EventHub.Business.Entities.Users;
using EventHub.Core.Entities;
using EventHub.Core.Exceptions;

namespace EventHub.Business.Entities.Events;

public sealed class Event : Entity<EventId>
{
    private readonly IList<EventSubscription> subscriptions = new List<EventSubscription>();

    public override EventId Id { get; init; } = EventId.New();

    public required UserId OwnerId { get; init; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required DateTimeOffset StartDate { get; set; }

    public required DateTimeOffset EndDate { get; set; }

    public required int Capacity { get; set; }

    public required EventType Type { get; set; }

    public required EventStatus Status { get; set; }

    public required EventSubscriptionBehavior SubscriptionBehavior { get; set; }

    public IReadOnlyList<EventSubscription> Subscriptions => subscriptions.AsReadOnly();

    public void AddSubscription(UserId userId)
    {
        ArgumentNullException.ThrowIfNull(userId);

        if (subscriptions.Any(s => s.UserId.Equals(userId)))
        {
            throw new DomainException($"User with id {userId} is already subscribed to event with id {Id}");
        }

        subscriptions.Add(new EventSubscription
        {
            EventId = Id,
            UserId = userId,
            SubscriptionDate = DateTimeOffset.UtcNow
        });
    }

    public void RemoveSubscription(UserId userId)
    {
        ArgumentNullException.ThrowIfNull(userId);

        var subscription = subscriptions.FirstOrDefault(s => s.UserId.Equals(userId));
        if (subscription is not null)
        {
            subscriptions.Remove(subscription);
        }
    }
}