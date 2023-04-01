using Domain.Entities;
using Domain.Repositories;

namespace Persistence.EntityFrameworkCore.Repositories;

public class KanbanRepository : EfCoreRepository<Kanban>, IKanbanRepository
{
    public KanbanRepository(AppDbContext context) : base(context) { }
}
