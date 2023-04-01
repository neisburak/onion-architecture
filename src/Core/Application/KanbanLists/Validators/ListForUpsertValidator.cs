using Application.KanbanLists.Models;
using FluentValidation;

namespace Application.KanbanLists.Validators;

public class ListForUpsertValidator : AbstractValidator<ListForUpsert>
{
    public ListForUpsertValidator()
    {
    }
}
