using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkCore.Configurations;

public class KanbanCardConfiguration : IEntityTypeConfiguration<KanbanCard>
{
    public void Configure(EntityTypeBuilder<KanbanCard> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(128);

        builder.OwnsOne(h => h.Color);
    }
}
