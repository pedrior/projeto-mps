using EventHub.Entities;
using EventHub.Infrastructure.Persistence.Context;

namespace EventHub.Infrastructure.Persistence.Repositories;

public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }

    public Category? FindByName(string name) =>
        Set.AsQueryable().FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}