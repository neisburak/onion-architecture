using Application.KanbanLists.Models;

namespace Application.KanbanLists;

public interface IKanbanListService
{
    Task<ListForView?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ListForView>> GetAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(ListForUpsert listForInsert, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, ListForUpsert listForUpdate, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
