using Application.KanbanCards.Models;

namespace Application.KanbanLists.Models;

public class DetailForList : ListForView
{
    public IEnumerable<CardForView> Cards { get; set; } = new List<CardForView>();
}
