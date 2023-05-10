using EventHub.Business.Entities.Users;
using EventHub.Core.Entities;

namespace EventHub.Business.Entities.Events;

public sealed class EventSubscription : Entity
{
    public required EventId EventId { get; init; }

    public required UserId UserId { get; init; }

    public required DateTimeOffset SubscriptionDate { get; init; }
}