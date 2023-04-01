namespace Application.KanbanLists.Models;

public class ListForUpsert
{
    public string Name { get; set; } = default!;
    public int Order { get; set; }
}
