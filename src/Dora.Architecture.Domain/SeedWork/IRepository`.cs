using Dora.Architecture.Domain.BlogAggregate;
using System.Linq.Expressions;

namespace Dora.Architecture.Domain.SeedWork;

public interface IRepository<TEntity> : IRepository<TEntity, int>
    where TEntity : IAggregateRoot
{

}

public interface IRepository<TEntity, TPrimaryKey> : IUnitOfWork
    where TEntity : IAggregateRoot
{
    void Insert(TEntity entity);

    void Delete(TEntity entity);

    void Update(TEntity entity);

    ValueTask<TEntity?> GetAsync(TPrimaryKey id);

    Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
}
