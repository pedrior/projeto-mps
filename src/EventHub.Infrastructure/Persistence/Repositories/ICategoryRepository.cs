using EventHub.Entities;

namespace EventHub.Infrastructure.Persistence.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Category? FindByName(string name);
}