using Dao.Repositories;
using Domain.FlattenDtos;
using GameService.Storages;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
[Route("icons")]
public class IconController(
    IIconStorage iconStorage,
    IIconRepository iconRepository
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateIcon([FromBody] IconApiModel icon)
    {
        await iconStorage.SaveAsync(icon);
        return Ok();
    }

    [HttpGet("{path}")]
    public async Task<IActionResult> GetIcon([FromRoute] string path)
    {
        var icon = await iconStorage.FindAsync(path);
        if (icon is null)
        {
            return NotFound();
        }

        return Ok(icon);
    }
}