using System.Linq.Expressions;
using EventHub.Entities;

namespace EventHub.Infrastructure.Persistence.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    void Add(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    TEntity? GetById(Guid id);

    IEnumerable<TEntity> GetAll();

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    bool Any(Expression<Func<TEntity, bool>> predicate);
}