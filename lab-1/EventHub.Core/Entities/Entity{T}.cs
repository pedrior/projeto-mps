namespace EventHub.Core.Entities;

public abstract class Entity<TId> : Entity, IEquatable<Entity<TId>>
{
    public virtual TId Id { get; init; } = default!;

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right) => Equals(left, right);

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right) => !Equals(left, right);

    public bool Equals(Entity<TId>? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        return ReferenceEquals(this, other) || EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj) || obj.GetType() != GetType())
        {
            return false;
        }

        return ReferenceEquals(this, obj) || Equals((Entity<TId>)obj);
    }

    public override int GetHashCode() => EqualityComparer<TId>.Default.GetHashCode(Id!);
}