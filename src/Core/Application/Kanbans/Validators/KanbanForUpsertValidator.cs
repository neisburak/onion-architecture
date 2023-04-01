using Application.Kanbans.Models;
using FluentValidation;

namespace Application.Kanbans.Validators;

public class KanbanForUpsertValidator : AbstractValidator<KanbanForUpsert>
{
    public KanbanForUpsertValidator()
    {
        RuleFor(r => r.Name).NotNull().NotEmpty();
    }
}
