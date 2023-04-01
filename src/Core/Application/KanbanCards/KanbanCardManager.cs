using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.KanbanCards.Models;
using Domain.Entities;
using Domain.Repositories;
using Mapster;

namespace Application.KanbanCards;

public class KanbanCardManager : IKanbanCardService
{
    private readonly IKanbanCardRepository _kanbanCardRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAsyncQueryExecuter _queryExecuter;

    public KanbanCardManager(IKanbanCardRepository kanbanCardRepository, IAsyncQueryExecuter queryExecuter, IUnitOfWork unitOfWork)
    {
        _kanbanCardRepository = kanbanCardRepository;
        _queryExecuter = queryExecuter;
        _unitOfWork = unitOfWork;
    }

    public async Task<CardForView?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _kanbanCardRepository.GetAsync(id, cancellationToken);

        if (entity is null) throw new EntityNotFoundException($"{nameof(KanbanCard)} with {id} not found.");
        return entity.Adapt<CardForView>();
    }

    public async Task<IEnumerable<CardForView>> GetAsync(CancellationToken cancellationToken = default)
    {
        var queryable = await _kanbanCardRepository.GetAsync(cancellationToken);

        return await _queryExecuter.ToListAsync(queryable.ProjectToType<CardForView>(), cancellationToken);
    }

    public async Task CreateAsync(CardForUpsert listForInsert, CancellationToken cancellationToken = default)
    {
        var entity = listForInsert.Adapt<KanbanCard>();
        await _kanbanCardRepository.InsertAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(int id, CardForUpsert listForUpdate, CancellationToken cancellationToken = default)
    {
        var entity = await _kanbanCardRepository.GetAsync(id, cancellationToken);

        if (entity is null) throw new EntityNotFoundException($"{nameof(KanbanCard)} with {id} not found.");

        entity.Name = listForUpdate.Name;

        await _kanbanCardRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default) => _kanbanCardRepository.RemoveAsync(id, cancellationToken);
}
