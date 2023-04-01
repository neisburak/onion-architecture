using Application.KanbanCards.Models;

namespace Application.KanbanCards;

public interface IKanbanCardService
{
    Task<CardForView?> GetAsync(int id);
    Task<IEnumerable<CardForView>> GetAsync();
    Task CreateAsync(CardForUpsert cardForInsert);
    Task UpdateAsync(int id, CardForUpsert cardForUpdate);
    Task DeleteAsync(int id);
}
