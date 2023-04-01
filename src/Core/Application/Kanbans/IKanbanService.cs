using Application.Kanbans.Models;

namespace Application.Kanbans;

public interface IKanbanService
{
    Task<KanbanForView?> GetAsync(int id);
    Task<IEnumerable<KanbanForView>> GetAsync();
    Task CreateAsync(KanbanForUpsert kanbanForInsert);
    Task UpdateAsync(int id, KanbanForUpsert kanbanForUpdate);
    Task DeleteAsync(int id);
}
