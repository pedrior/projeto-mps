namespace EventHub.Utils.Persistence;

public abstract class DbContext
{
    private readonly Dictionary<Type, object> sets = new();

    protected DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        if (!sets.ContainsKey(typeof(TEntity)))
        {
            sets[typeof(TEntity)] = new DbSet<TEntity>();
        }
        
        return (DbSet<TEntity>)sets[typeof(TEntity)];
    }
}