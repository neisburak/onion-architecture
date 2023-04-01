using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityFrameworkCore;

public class AsyncQueryExecuter : IAsyncQueryExecuter
{
    public Task<bool> AnyAsync<TType>(IQueryable<TType> queryable, CancellationToken cancellationToken = default) => queryable.AnyAsync(cancellationToken);

    public Task<int> CountAsync<TType>(IQueryable<TType> queryable, CancellationToken cancellationToken = default) => queryable.CountAsync(cancellationToken);

    public Task<TType?> FirstOrDefaultAsync<TType>(IQueryable<TType> queryable, CancellationToken cancellationToken = default) => queryable.FirstOrDefaultAsync(cancellationToken);

    public Task<List<TType>> ToListAsync<TType>(IQueryable<TType> queryable, CancellationToken cancellationToken = default) => queryable.ToListAsync(cancellationToken);
}
