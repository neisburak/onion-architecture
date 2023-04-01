using Domain.Repositories;

namespace Application.Kanbans;

public class KanbanManager : IKanbanService
{
    private readonly IKanbanRepository _kanbanRepository;

    public KanbanManager(IKanbanRepository kanbanRepository)
    {
        _kanbanRepository = kanbanRepository;
    }
}
