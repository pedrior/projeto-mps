namespace EventHub.Business.Entities.Events;

public sealed record EventId
{
    private EventId(Guid value) => Value = value;

    public Guid Value { get; }

    public static EventId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}