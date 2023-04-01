using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.KanbanCards.Models;
using Application.KanbanLists.Models;
using Domain.Entities;
using Domain.Repositories;
using Mapster;

namespace Application.KanbanLists;

public class KanbanListManager : IKanbanListService
{
    private readonly IKanbanListRepository _kanbanListRepository;
    private readonly IKanbanCardRepository _kanbanCardRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAsyncQueryExecuter _queryExecuter;

    public KanbanListManager(IKanbanListRepository kanbanListRepository, IAsyncQueryExecuter queryExecuter, IUnitOfWork unitOfWork, IKanbanCardRepository kanbanCardRepository)
    {
        _kanbanListRepository = kanbanListRepository;
        _queryExecuter = queryExecuter;
        _unitOfWork = unitOfWork;
        _kanbanCardRepository = kanbanCardRepository;
    }

    public async Task<ListForView?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _kanbanListRepository.GetAsync(id, cancellationToken);

        if (entity is null) throw new EntityNotFoundException($"{nameof(KanbanList)} with {id} not found.");
        return entity.Adapt<ListForView>();
    }

    public async Task<DetailForList?> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        var queryable = from list in await _kanbanListRepository.GetAsync(cancellationToken)
                        where list.Id == id
                        orderby list.Order descending
                        select new DetailForList
                        {
                            Id = list.Id,
                            Name = list.Name,
                            CreatedOn = list.CreatedOn,
                            ModifiedOn = list.ModifiedOn,
                            Order = list.Order,
                            Cards = list.Cards.Select(s => new CardForView
                            {
                                Id = s.Id,
                                Name = s.Name,
                                Color = s.Color,
                                Description = s.Description,
                                Priority = s.Priority
                            })
                        };

        return await _queryExecuter.FirstOrDefaultAsync(queryable, cancellationToken);
    }

    public async Task<IEnumerable<ListForView>> GetAsync(CancellationToken cancellationToken = default)
    {
        var queryable = await _kanbanListRepository.GetAsync(cancellationToken);

        return await _queryExecuter.ToListAsync(queryable.ProjectToType<ListForView>(), cancellationToken);
    }

    public async Task CreateAsync(ListForUpsert listForInsert, CancellationToken cancellationToken = default)
    {
        var entity = listForInsert.Adapt<KanbanList>();
        await _kanbanListRepository.InsertAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(int id, ListForUpsert listForUpdate, CancellationToken cancellationToken = default)
    {
        var entity = await _kanbanListRepository.GetAsync(id, cancellationToken);

        if (entity is null) throw new EntityNotFoundException($"{nameof(KanbanList)} with {id} not found.");

        entity.Name = listForUpdate.Name;

        await _kanbanListRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _kanbanListRepository.RemoveAsync(id, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
