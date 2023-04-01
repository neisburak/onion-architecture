using Application.Kanbans;
using Application.Kanbans.Models;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _kanbanService.GetAsync(id, cancellationToken);

        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpGet("{id}/details")]
    public async Task<IActionResult> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _kanbanService.GetDetailsAsync(id, cancellationToken);

        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default)
    {
        var result = await _kanbanService.GetAsync(cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] KanbanForUpsert kanbanForInsert, CancellationToken cancellationToken = default)
    {
        await _kanbanService.CreateAsync(kanbanForInsert, cancellationToken);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] KanbanForUpsert kanbanForUpdate, CancellationToken cancellationToken = default)
    {
        await _kanbanService.UpdateAsync(id, kanbanForUpdate, cancellationToken);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _kanbanService.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}
