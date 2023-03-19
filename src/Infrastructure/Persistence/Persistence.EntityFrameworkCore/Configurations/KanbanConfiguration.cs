using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkCore.Configurations;

public class KanbanConfiguration : IEntityTypeConfiguration<Kanban>
{
    public void Configure(EntityTypeBuilder<Kanban> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(32);
    }
}