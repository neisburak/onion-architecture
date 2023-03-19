using Domain.Common;

namespace Domain.Entities;

public class Kanban : AuditableEntity
{
    public string Name { get; set; } = default!;
    public virtual ICollection<KanbanList> Lists { get; set; } = new HashSet<KanbanList>();
}