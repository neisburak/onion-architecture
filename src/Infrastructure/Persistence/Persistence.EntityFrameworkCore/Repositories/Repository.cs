using System.Linq.Expressions;
using Domain.Common;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityFrameworkCore.Repositories;

public class Repository<TEntity> : Repository<TEntity, int>, IRepository<TEntity> where TEntity : Entity<int>, new()
{
    public Repository(AppDbContext context) : base(context) { }
}

public class Repository<TEntity, TKey> : RepositoryBase<TEntity, TKey>, IRepository<TEntity, TKey> where TEntity : Entity<TKey>, new()
{
    protected AppDbContext DbContext { get; }
    protected DbSet<TEntity> DbSet { get; }

    public Repository(AppDbContext context)
    {
        DbContext = context;
        DbSet = DbContext.Set<TEntity>();
    }

    public DbContext GetDbContext() => DbContext;
    public Task<DbContext> GetDbContextAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(GetDbContext());
    }

    public DbSet<TEntity> GetDbSet() => DbSet;
    public Task<DbSet<TEntity>> GetDbSetAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(GetDbSet());
    }

    public override TEntity? Get(TKey id) => DbSet.FirstOrDefault(CreateEqualityExpressionForId(id));
    public override Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return DbSet.FirstOrDefaultAsync(CreateEqualityExpressionForId(id), cancellationToken);
    }

    public override IQueryable<TEntity> Get() => DbSet;
    public override Task<IQueryable<TEntity>> GetAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Get());
    }

    public override IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => DbSet.Where(predicate);
    public override Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Get(predicate));
    }

    public override TEntity? GetOrDefault(Expression<Func<TEntity, bool>> predicate) => DbSet.FirstOrDefault(predicate);
    public override Task<TEntity?> GetOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public override TEntity Insert(TEntity entity) => DbSet.Add(entity).Entity;
    public override async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return (await DbSet.AddAsync(entity, cancellationToken)).Entity;
    }

    public override void Remove(TEntity entity)
    {
        AttachIfNot(entity);
        DbSet.Remove(entity);
    }
    public override Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Remove(entity);
        return Task.CompletedTask;
    }

    public override void Remove(TKey id)
    {
        var entity = GetFromChangeTrackerOrNull(id);
        if (entity is not null)
        {
            Remove(entity);
            return;
        }

        entity = Get(id);
        if (entity is not null)
        {
            Remove(entity);
            return;
        }
    }
    public override Task RemoveAsync(TKey id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Remove(id);
        return Task.CompletedTask;
    }

    public override TEntity Update(TEntity entity)
    {
        AttachIfNot(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
        return entity;
    }
    public override Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(Update(entity));
    }

    public override bool Any(Expression<Func<TEntity, bool>> predicate) => DbSet.Any(predicate);
    public override Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return DbSet.AnyAsync(predicate, cancellationToken);
    }

    public override int Count(Expression<Func<TEntity, bool>> predicate) => DbSet.Count(predicate);
    public override Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return DbSet.CountAsync(predicate, cancellationToken);
    }

    #region Helpers
    private void AttachIfNot(TEntity entity)
    {
        var isAttached = DbContext.ChangeTracker.Entries().Any(f => f.Entity == entity);
        if (!isAttached) DbContext.Attach(entity);
    }
    private TEntity? GetFromChangeTrackerOrNull(TKey id)
    {
        var entry = DbContext.ChangeTracker.Entries().FirstOrDefault(f => f.Entity is TEntity entity && EqualityComparer<TKey>.Default.Equals(id, entity.Id));
        return entry?.Entity as TEntity;
    }
    #endregion
}