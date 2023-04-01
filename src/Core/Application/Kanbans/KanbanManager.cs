using Application.Kanbans.Models;
using Domain.Repositories;

namespace Application.Kanbans;

public class KanbanManager : IKanbanService
{
    private readonly IKanbanRepository _kanbanRepository;

    public KanbanManager(IKanbanRepository kanbanRepository)
    {
        _kanbanRepository = kanbanRepository;
    }

    public Task CreateAsync(KanbanForUpsert kanbanForInsert)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<KanbanForView?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<KanbanForView>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, KanbanForUpsert kanbanForUpdate)
    {
        throw new NotImplementedException();
    }
}
