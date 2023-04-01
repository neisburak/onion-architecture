namespace Application.Common.Interfaces;

public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync(CancellationToken cancellationToken = default);
}
