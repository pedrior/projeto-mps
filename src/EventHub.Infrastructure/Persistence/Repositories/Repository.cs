using System.Linq.Expressions;
using EventHub.Entities;
using EventHub.Infrastructure.Persistence.Context;

namespace EventHub.Infrastructure.Persistence.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbContext context;

    protected Repository(DbContext context)
    {
        this.context = context;
    }

    protected DbSet<TEntity> Set => context.Set<TEntity>();

    public void Add(TEntity entity) => Set.Add(entity);

    public void Update(TEntity entity) => Set.Update(entity);

    public void Delete(TEntity entity) => Set.Remove(entity);

    public TEntity? GetById(Guid id) => Set.AsQueryable().FirstOrDefault(x => x.Id == id);

    public IEnumerable<TEntity> GetAll() => Set.AsEnumerable();

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
        Set.AsQueryable().Where(predicate).AsEnumerable();

    public bool Any(Expression<Func<TEntity, bool>> predicate) => Set.AsQueryable().Any(predicate);
}