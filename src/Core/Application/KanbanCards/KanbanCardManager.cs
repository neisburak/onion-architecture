using Application.KanbanCards.Models;
using Domain.Repositories;

namespace Application.KanbanCards;

public class KanbanCardManager : IKanbanCardService
{
    private readonly IKanbanCardRepository _kanbanCardRepository;

    public KanbanCardManager(IKanbanCardRepository kanbanCardRepository)
    {
        _kanbanCardRepository = kanbanCardRepository;
    }

    public Task CreateAsync(CardForUpsert cardForInsert)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CardForView?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CardForView>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, CardForUpsert cardForUpdate)
    {
        throw new NotImplementedException();
    }
}
