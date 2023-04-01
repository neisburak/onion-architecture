using Application.KanbanCards.Models;
using FluentValidation;

namespace Application.KanbanCards.Validators;

public class CardForUpsertValidator : AbstractValidator<CardForUpsert>
{
    public CardForUpsertValidator()
    {
    }
}
