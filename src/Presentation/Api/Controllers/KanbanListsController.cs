using Application.KanbanLists;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController, Route("api/[controller]")]
public class KanbanListsController : ControllerBase
{
    private readonly IKanbanListService _kanbanListService;

    public KanbanListsController(IKanbanListService kanbanListService)
    {
        _kanbanListService = kanbanListService;
    }
}
