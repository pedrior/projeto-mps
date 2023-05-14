using EventHub.Entities;

namespace EventHub.Infrastructure.Persistence.Repositories;

public interface IEventRepository : IRepository<Event>
{
    Event? FindById(Guid id);
}