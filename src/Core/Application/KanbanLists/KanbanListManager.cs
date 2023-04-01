using Application.KanbanLists.Models;
using Domain.Repositories;

namespace Application.KanbanLists;

public class KanbanListManager : IKanbanListService
{
    private readonly IKanbanListRepository _kanbanListRepository;

    public KanbanListManager(IKanbanListRepository kanbanListRepository)
    {
        _kanbanListRepository = kanbanListRepository;
    }

    public Task CreateAsync(ListForUpsert listForInsert)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ListForView?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ListForView>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, ListForUpsert listForUpdate)
    {
        throw new NotImplementedException();
    }
}
