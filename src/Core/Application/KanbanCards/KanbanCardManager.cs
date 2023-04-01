using Domain.Repositories;

namespace Application.KanbanCards;

public class KanbanCardManager : IKanbanCardService
{
    private readonly IKanbanCardRepository _kanbanCardRepository;

    public KanbanCardManager(IKanbanCardRepository kanbanCardRepository)
    {
        _kanbanCardRepository = kanbanCardRepository;
    }
}
