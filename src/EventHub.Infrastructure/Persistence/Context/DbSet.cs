namespace EventHub.Infrastructure.Persistence.Context;

public sealed class DbSet<TEntity> where TEntity : class
{
    private readonly HashSet<TEntity> set;

    public DbSet()
    {
        set = new HashSet<TEntity>();
    }

    internal DbSet(IEnumerable<TEntity> entities)
    {
        set = new HashSet<TEntity>(entities);
    }

    public int Count => set.Count;

    internal bool IsDirty { get; private set; }

    public IQueryable<TEntity> AsQueryable() => set.AsQueryable();

    public IEnumerable<TEntity> AsEnumerable() => set.AsEnumerable();

    public void Add(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        set.Add(entity);
        MarkAsDirty();
    }

    public bool Remove(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        if (!set.Remove(entity))
        {
            return false;
        }

        MarkAsDirty();
        return true;
    }

    public bool Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        if (!set.Remove(entity))
        {
            return false;
        }

        set.Add(entity);
        MarkAsDirty();

        return true;
    }

    internal void MarkAsClean() => IsDirty = false;

    private void MarkAsDirty() => IsDirty = true;
}