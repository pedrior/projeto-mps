using EventHub.Core.Entities;

namespace EventHub.Business.Entities.Categories;

public sealed class Category : Entity<CategoryId>
{
    public override CategoryId Id { get; init; } = CategoryId.New();

    public required string Name { get; set; }

    public required string Description { get; set; }
}