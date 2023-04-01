namespace Application.KanbanLists.Models;

public class ListForUpsert
{
    public int KanbanId { get; set; }
    public string Name { get; set; } = default!;
    public int Order { get; set; }
}
