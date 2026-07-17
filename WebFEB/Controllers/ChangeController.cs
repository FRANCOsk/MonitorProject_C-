using Microsoft.AspNetCore.Mvc;
using WebFEB.Models;
using WebFEB.Services;

namespace WebFEB.Controllers;

[ApiController]
[Route("api/changes")]
public class ChangeController : ControllerBase
{
    private readonly IChangeService _changeService;

    public ChangeController(IChangeService changeService)
    {
        _changeService = changeService;
    }

    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok(new { status = "healthy" });
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<ChangeDTO>>> GetChanges()
    {
        List<ChangeDTO> changes = await _changeService.GetAllChangesAsync();
        return Ok(changes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ChangeDTO>> GetChangeById(int id)
    {
        ChangeDTO? change = await _changeService.GetChangeByIdAsync(id);
        return change is null ? NotFound() : Ok(change);
    }
}
