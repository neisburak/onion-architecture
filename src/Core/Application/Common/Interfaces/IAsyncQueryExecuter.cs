namespace Application.Common.Interfaces;

public interface IAsyncQueryExecuter
{
    Task<int> CountAsync<TType>(IQueryable<TType> queryable, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync<TType>(IQueryable<TType> queryable, CancellationToken cancellationToken = default);
    Task<TType?> FirstOrDefaultAsync<TType>(IQueryable<TType> queryable, CancellationToken cancellationToken = default);
    Task<List<TType>> ToListAsync<TType>(IQueryable<TType> queryable, CancellationToken cancellationToken = default);
}
