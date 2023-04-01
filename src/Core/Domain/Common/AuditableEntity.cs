namespace Domain.Common;

public abstract class AuditableEntity : AuditableEntity<int> { }

public abstract class AuditableEntity<TKey> : Entity<TKey>
{
    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }
}