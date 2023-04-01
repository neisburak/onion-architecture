using Application.KanbanLists.Models;

namespace Application.KanbanLists;

public interface IKanbanListService
{
    Task<ListForView?> GetAsync(int id);
    Task<IEnumerable<ListForView>> GetAsync();
    Task CreateAsync(ListForUpsert listForInsert);
    Task UpdateAsync(int id, ListForUpsert listForUpdate);
    Task DeleteAsync(int id);
}
