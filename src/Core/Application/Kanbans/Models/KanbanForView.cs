namespace Application.Kanbans.Models;

public class KanbanForView
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
