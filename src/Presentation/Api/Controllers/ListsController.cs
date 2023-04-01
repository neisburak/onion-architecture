using Application.KanbanLists;
using Application.KanbanLists.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController, Route("api/[controller]")]
public class ListsController : ControllerBase
{
    private readonly IKanbanListService _kanbanListService;

    public ListsController(IKanbanListService kanbanListService)
    {
        _kanbanListService = kanbanListService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _kanbanListService.GetAsync(id, cancellationToken);

        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpGet("{id}/details")]
    public async Task<IActionResult> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _kanbanListService.GetDetailsAsync(id, cancellationToken);

        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default)
    {
        var result = await _kanbanListService.GetAsync(cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ListForUpsert listForInsert, CancellationToken cancellationToken = default)
    {
        await _kanbanListService.CreateAsync(listForInsert, cancellationToken);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ListForUpsert listForUpdate, CancellationToken cancellationToken = default)
    {
        await _kanbanListService.UpdateAsync(id, listForUpdate, cancellationToken);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _kanbanListService.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}