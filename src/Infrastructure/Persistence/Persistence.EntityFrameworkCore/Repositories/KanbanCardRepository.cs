using Domain.Entities;
using Domain.Repositories;

namespace Persistence.EntityFrameworkCore.Repositories;

public class KanbanCardRepository : Repository<KanbanCard>, IKanbanCardRepository
{
    public KanbanCardRepository(AppDbContext context) : base(context) { }
}