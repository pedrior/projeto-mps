using EventHub.Entities;
using EventHub.Infrastructure.Persistence.Context;

namespace EventHub.Infrastructure.Persistence.Repositories;

public sealed class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(DbContext context) : base(context)
    {
    }

    public Event? FindById(Guid id)
    {
        return Set.AsQueryable().FirstOrDefault(x => x.Id == id);
    }
}