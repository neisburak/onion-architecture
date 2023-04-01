using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.KanbanLists.Models;
using Domain.Entities;
using Domain.Repositories;
using Mapster;

namespace Application.KanbanLists;

public class KanbanListManager : IKanbanListService
{
    private readonly IKanbanListRepository _kanbanListRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAsyncQueryExecuter _queryExecuter;

    public KanbanListManager(IKanbanListRepository kanbanListRepository, IAsyncQueryExecuter queryExecuter, IUnitOfWork unitOfWork)
    {
        _kanbanListRepository = kanbanListRepository;
        _queryExecuter = queryExecuter;
        _unitOfWork = unitOfWork;
    }

    public async Task<ListForView?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _kanbanListRepository.GetAsync(id, cancellationToken);

        if (entity is null) throw new EntityNotFoundException($"{nameof(KanbanList)} with {id} not found.");
        return entity.Adapt<ListForView>();
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

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default) => _kanbanListRepository.RemoveAsync(id, cancellationToken);
}
