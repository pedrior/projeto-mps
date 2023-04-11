using EventHub.Utils.Entities;

namespace EventHub.Infrastructure.Persistence;

public sealed class MemoryCollection<TEntity, TId> where TEntity : Entity<TId> where TId : notnull
{
    private readonly HashSet<TEntity> set = new();

    public void Add(TEntity entity)
    {
        if (set.Any(e => entity.Id.Equals(e.Id)))
        {
            throw new MemoryCollectionException("An entity with the same ID already exists.");
        }

        set.Add(entity);
    }
    
    public IEnumerable<TEntity> GetAll() => set;

    public TEntity? GetSingle(TId id) => set.SingleOrDefault(e => id.Equals(e.Id));

    public bool Exists(TId id) => set.Any(e => id.Equals(e.Id));
    
    public bool Exists(TEntity entity) => set.Any(e => entity.Id.Equals(e.Id));
    
    public bool Exists(Func<TEntity, bool> predicate) => set.Any(predicate);
    
    public void Update(TEntity entity)
    {
        if (set.RemoveWhere(e => e.Id.Equals(entity.Id)) == 1)
        {
            set.Add(entity);
        }
    }

    public void Remove(TEntity entity) => set.Remove(entity);
}