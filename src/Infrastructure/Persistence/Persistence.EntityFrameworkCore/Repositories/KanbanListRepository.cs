using Domain.Entities;
using Domain.Repositories;

namespace Persistence.EntityFrameworkCore.Repositories;

public class KanbanListRepository : Repository<KanbanList>, IKanbanListRepository
{
    public KanbanListRepository(AppDbContext context) : base(context) { }
}