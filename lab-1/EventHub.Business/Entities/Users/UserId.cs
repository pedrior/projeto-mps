namespace EventHub.Business.Entities.Users;

public sealed record UserId
{
    private UserId(Guid value) => Value = value;

    public Guid Value { get; }

    public static UserId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}