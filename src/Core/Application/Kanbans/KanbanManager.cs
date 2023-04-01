using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.KanbanCards.Models;
using Application.KanbanLists.Models;
using Application.Kanbans.Models;
using Domain.Entities;
using Domain.Repositories;
using Mapster;

namespace Application.Kanbans;

public class KanbanManager : IKanbanService
{
    private readonly IKanbanRepository _kanbanRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAsyncQueryExecuter _queryExecuter;

    public KanbanManager(IKanbanRepository kanbanRepository, IAsyncQueryExecuter queryExecuter, IUnitOfWork unitOfWork)
    {
        _kanbanRepository = kanbanRepository;
        _queryExecuter = queryExecuter;
        _unitOfWork = unitOfWork;
    }

    public async Task<KanbanForView?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _kanbanRepository.GetAsync(id, cancellationToken);

        if (entity is null) throw new EntityNotFoundException($"{nameof(Kanban)} with {id} not found.");
        return entity.Adapt<KanbanForView>();
    }

    public async Task<DetailForKanban?> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        var queryable = from kanban in await _kanbanRepository.GetAsync(cancellationToken)
                        where kanban.Id == id
                        orderby kanban.Name
                        select new DetailForKanban
                        {
                            Id = kanban.Id,
                            Name = kanban.Name,
                            CreatedOn = kanban.CreatedOn,
                            ModifiedOn = kanban.ModifiedOn,
                            Lists = kanban.Lists.Select(s => new DetailForList
                            {
                                Id = s.Id,
                                Name = s.Name,
                                CreatedOn = s.CreatedOn,
                                ModifiedOn = s.ModifiedOn,
                                Order = s.Order,
                                Cards = s.Cards.Select(s => new CardForView
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    Color = s.Color,
                                    Description = s.Description,
                                    Priority = s.Priority
                                })
                            })
                        };

        return await _queryExecuter.FirstOrDefaultAsync(queryable, cancellationToken);
    }

    public async Task<IEnumerable<KanbanForView>> GetAsync(CancellationToken cancellationToken = default)
    {
        var queryable = await _kanbanRepository.GetAsync(cancellationToken);

        return await _queryExecuter.ToListAsync(queryable.ProjectToType<KanbanForView>(), cancellationToken);
    }

    public async Task CreateAsync(KanbanForUpsert kanbanForInsert, CancellationToken cancellationToken = default)
    {
        var entity = kanbanForInsert.Adapt<Kanban>();
        await _kanbanRepository.InsertAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(int id, KanbanForUpsert kanbanForUpdate, CancellationToken cancellationToken = default)
    {
        var entity = await _kanbanRepository.GetAsync(id, cancellationToken);

        if (entity is null) throw new EntityNotFoundException($"{nameof(Kanban)} with {id} not found.");

        entity.Name = kanbanForUpdate.Name;

        await _kanbanRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _kanbanRepository.RemoveAsync(id, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}