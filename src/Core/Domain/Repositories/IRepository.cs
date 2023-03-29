using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Repositories;

public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : Entity<int>, new() { }

public interface IRepository<TEntity, in TKey> where TEntity : Entity<TKey>, new()
{
    #region Select
    TEntity? Get(TKey id);
    Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken = default);

    TEntity? GetOrDefault(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> GetOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    IQueryable<TEntity> Get();
    Task<IQueryable<TEntity>> GetAsync(CancellationToken cancellationToken = default);

    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    #endregion

    #region Insert
    TEntity Insert(TEntity entity);
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    #endregion

    #region Update
    TEntity Update(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    #endregion

    #region Remove
    void Remove(TEntity entity);
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Remove(TKey id);
    Task RemoveAsync(TKey id, CancellationToken cancellationToken = default);
    #endregion

    #region Aggregates
    int Count(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    bool Any(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    #endregion
}