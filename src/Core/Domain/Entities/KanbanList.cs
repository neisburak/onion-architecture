using Domain.Common;

namespace Domain.Entities;

public class KanbanList : AuditableEntity
{
    public int KanbanId { get; set; }
    public string Name { get; set; } = default!;
    public int Order { get; set; }

    public virtual Kanban Kanban { get; set; } = default!;
    public virtual ICollection<KanbanCard> Cards { get; set; } = new HashSet<KanbanCard>();
}