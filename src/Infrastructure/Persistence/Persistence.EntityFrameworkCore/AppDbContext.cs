using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Kanban> Kanbans => Set<Kanban>();
    public DbSet<KanbanList> KanbanLists => Set<KanbanList>();
    public DbSet<KanbanCard> KanbanCards => Set<KanbanCard>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}