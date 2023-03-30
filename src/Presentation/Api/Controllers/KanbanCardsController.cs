using Application.KanbanCards;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController, Route("api/[controller]")]
public class KanbanCardsController : ControllerBase
{
    private readonly IKanbanCardService _kanbanCardService;

    public KanbanCardsController(IKanbanCardService kanbanCardService)
    {
        _kanbanCardService = kanbanCardService;
    }
}
