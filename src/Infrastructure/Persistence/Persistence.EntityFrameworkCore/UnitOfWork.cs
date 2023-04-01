using Application.Common.Interfaces;

namespace Persistence.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    protected AppDbContext DbContext { get; }

    public UnitOfWork(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void Commit() => DbContext.SaveChanges();

    public Task CommitAsync(CancellationToken cancellationToken = default) => DbContext.SaveChangesAsync(cancellationToken);
}
