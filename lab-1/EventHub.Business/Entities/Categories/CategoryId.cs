namespace EventHub.Business.Entities.Categories;

public sealed record CategoryId
{
    private CategoryId(Guid value) => Value = value;

    public Guid Value { get; }

    public static CategoryId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}