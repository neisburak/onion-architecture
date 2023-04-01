using Domain.Enums;

namespace Application.KanbanCards.Models;

public class CardForUpsert
{
    public int ListId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Color { get; set; }
    public Priority Priority { get; set; }
}
