using Domain.Scheduler;
using GameService.Storages;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
[Route("action-areas")]
public class ActionAreaController(
    IActionAreaStorage actionAreaStorage
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTool([FromBody] ActionArea actionArea)
    {
        await actionAreaStorage.StoreAsync(actionArea);
        return Ok();
    }

    [HttpGet(nameof(actionAreaId))]
    public async Task<IActionResult> GetTool([FromRoute] Guid actionAreaId)
    {
        var actionArea = await actionAreaStorage.FindAsync(actionAreaId);
        if (actionArea is null)
        {
            return NotFound();
        }

        return Ok(actionArea);
    }
}