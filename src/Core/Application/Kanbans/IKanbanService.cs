using Application.Kanbans.Models;

namespace Application.Kanbans;

public interface IKanbanService
{
    Task<KanbanForView?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<DetailForKanban?> GetDetailsAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<KanbanForView>> GetAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(KanbanForUpsert kanbanForInsert, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, KanbanForUpsert kanbanForUpdate, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
