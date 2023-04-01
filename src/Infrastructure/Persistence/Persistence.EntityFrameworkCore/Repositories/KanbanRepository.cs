using Domain.Entities;
using Domain.Repositories;

namespace Persistence.EntityFrameworkCore.Repositories;

public class KanbanRepository : Repository<Kanban>, IKanbanRepository
{
    public KanbanRepository(AppDbContext context) : base(context) { }
}
