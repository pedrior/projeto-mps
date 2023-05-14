namespace EventHub.Infrastructure.Persistence.Context;

public abstract class DbContext
{
    protected internal DbContext()
    {
    }

    internal abstract DbSet<TEntity> Set<TEntity>() where TEntity : class;

    public abstract void SaveChanges();
}