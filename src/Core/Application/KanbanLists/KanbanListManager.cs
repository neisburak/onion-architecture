using Domain.Repositories;

namespace Application.KanbanLists;

public class KanbanListManager : IKanbanListService
{
    private readonly IKanbanListRepository _kanbanListRepository;

    public KanbanListManager(IKanbanListRepository kanbanListRepository)
    {
        _kanbanListRepository = kanbanListRepository;
    }
}
