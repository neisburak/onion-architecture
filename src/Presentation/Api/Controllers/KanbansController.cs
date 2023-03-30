using Application.Kanbans;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController, Route("api/[controller]")]
public class KanbansController : ControllerBase
{
    private readonly IKanbanService _kanbanService;

    public KanbansController(IKanbanService kanbanService)
    {
        _kanbanService = kanbanService;
    }
}
