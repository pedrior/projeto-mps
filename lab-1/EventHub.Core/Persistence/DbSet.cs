namespace EventHub.Core.Persistence;

public sealed class DbSet<TEntity>  where TEntity : class
{
    private readonly HashSet<TEntity> set = new();

    public int Count => set.Count;
    
    public IQueryable<TEntity> AsQueryable() => set.AsQueryable();
    
    public IEnumerable<TEntity> AsEnumerable() => set.AsEnumerable();

    public void Add(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        set.Add(entity);
    }

    public void Remove(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        set.Remove(entity);
    }

    public bool Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var entry = set.FirstOrDefault(e => e == entity);
        if (entry is null)
        {
            return false;
        }

        set.Remove(entry);
        set.Add(entity);

        return true;
    }
}