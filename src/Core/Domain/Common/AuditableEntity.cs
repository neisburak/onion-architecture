namespace Domain.Common;

public class AuditableEntity : AuditableEntity<int> { }

public class AuditableEntity<TKey> : Entity<TKey>
{
    public DateTime CreatedOn { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
    public string? ModifiedBy { get; set; }
}