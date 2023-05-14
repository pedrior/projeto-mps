using System.Text;

namespace EventHub.Entities;

public sealed class Category : Entity
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public Category CopyWith(string? name = null, string? description = null) => new()
    {
        Id = Id,
        Name = name ?? Name,
        Description = description ?? Description
    };

    public override string ToString() =>
        new StringBuilder()
            .AppendLine($"Name: {Name}")
            .AppendLine($"Description: {Description}")
            .ToString();
}
