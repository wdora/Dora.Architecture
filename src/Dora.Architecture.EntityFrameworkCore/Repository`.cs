using Dora.Architecture.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dora.Architecture.EntityFrameworkCore
{
    public class Repository<TEntity> : Repository<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public Repository(DbContext currentDb) : base(currentDb)
        {
        }
    }

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot
    {
        DbContext _currentDb;

        public Repository(DbContext currentDb)
        {
            this._currentDb = currentDb;
        }

        public void Delete(TEntity entity)
        {
            _currentDb.Set<TEntity>().Remove(entity);
        }

        public void Dispose()
        {
            _currentDb.Dispose();
        }

        public Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _currentDb.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public ValueTask<TEntity?> GetAsync(TKey id)
        {
            return _currentDb.Set<TEntity>().FindAsync(id);
        }

        public void Insert(TEntity entity)
        {
            _currentDb.Set<TEntity>().Add(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _currentDb.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _currentDb.Set<TEntity>().Update(entity);
        }
    }
}
