using Application.KanbanCards;
using Application.KanbanCards.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController, Route("api/[controller]")]
public class CardsController : ControllerBase
{
    private readonly IKanbanCardService _kanbanCardService;

    public CardsController(IKanbanCardService kanbanCardService)
    {
        _kanbanCardService = kanbanCardService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _kanbanCardService.GetAsync(id, cancellationToken);

        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default)
    {
        var result = await _kanbanCardService.GetAsync(cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CardForUpsert cardForInsert, CancellationToken cancellationToken = default)
    {
        await _kanbanCardService.CreateAsync(cardForInsert, cancellationToken);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] CardForUpsert cardForUpdate, CancellationToken cancellationToken = default)
    {
        await _kanbanCardService.UpdateAsync(id, cardForUpdate, cancellationToken);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _kanbanCardService.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}