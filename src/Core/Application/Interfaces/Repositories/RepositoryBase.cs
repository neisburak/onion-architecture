using System.Linq.Expressions;
using Domain.Common;

namespace Application.Interfaces.Repositories;

public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>, new()
{
    public virtual TEntity? Get(TKey id) => Get().FirstOrDefault(CreateEqualityExpressionForId(id));
    public virtual Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Get(id));
    }

    public virtual TEntity? GetOrDefault(Expression<Func<TEntity, bool>> predicate) => Get(predicate).FirstOrDefault();
    public virtual Task<TEntity?> GetOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(GetOrDefault(predicate));
    }

    public abstract IQueryable<TEntity> Get();
    public virtual Task<IQueryable<TEntity>> GetAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Get());
    }

    public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => Get().Where(predicate);
    public virtual Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Get(predicate));
    }

    public abstract TEntity Insert(TEntity entity);
    public virtual Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Insert(entity));
    }

    public virtual void Remove(TEntity entity) => Remove(entity.Id);
    public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default) => RemoveAsync(entity.Id, cancellationToken);

    public abstract void Remove(TKey id);
    public virtual Task RemoveAsync(TKey id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Remove(id);
        return Task.CompletedTask;
    }

    public abstract TEntity Update(TEntity entity);
    public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Update(entity));
    }

    public virtual bool Any(Expression<Func<TEntity, bool>> predicate) => Get().Any(predicate);
    public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Any(predicate));
    }

    public virtual int Count(Expression<Func<TEntity, bool>> predicate) => Get().Count(predicate);
    public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Count(predicate));
    }

    protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TKey id)
    {
        var lambdaParam = Expression.Parameter(typeof(TEntity));
        var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

        var idValue = Convert.ChangeType(id, typeof(TKey));

        Expression<Func<object>> closure = () => idValue;
        var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

        var lambdaBody = Expression.Equal(leftExpression, rightExpression);

        return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
    }
}