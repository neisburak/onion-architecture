using Application.KanbanCards.Models;

namespace Application.KanbanCards;

public interface IKanbanCardService
{
    Task<CardForView?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CardForView>> GetAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(CardForUpsert cardForInsert, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, CardForUpsert cardForUpdate, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
