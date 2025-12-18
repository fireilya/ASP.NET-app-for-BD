using Domain.Scheduler;
using GameService.Storages;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
[Route("tools")]
public class ToolController(
    IToolStorage toolStorage
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTool([FromBody] Tool tool)
    {
        await toolStorage.SaveAsync(tool);
        return Ok();
    }

    [HttpGet(nameof(toolId))]
    public async Task<IActionResult> GetTool([FromRoute] Guid toolId)
    {
        var tool = await toolStorage.FindAsync(toolId);
        if (tool is null)
        {
            return NotFound();
        }

        return Ok(tool);
    }
}