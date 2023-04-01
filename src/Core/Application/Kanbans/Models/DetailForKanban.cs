using Application.KanbanLists.Models;

namespace Application.Kanbans.Models;

public class DetailForKanban : KanbanForView
{
    public IEnumerable<DetailForList> Lists { get; set; } = new List<DetailForList>();
}
