using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkCore.Configurations;

public class KanbanListConfiguration : IEntityTypeConfiguration<KanbanList>
{
    public void Configure(EntityTypeBuilder<KanbanList> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(64);
    }
}