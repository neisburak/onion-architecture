using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class KanbanCard : AuditableEntity
{
    public int ListId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public Color? Color { get; set; }
    public Priority Priority { get; set; } = Priority.None;

    public bool HasDescription => !string.IsNullOrEmpty(Description);

    public virtual KanbanList List { get; set; } = default!;
}