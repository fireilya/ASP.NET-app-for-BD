using Dao.Repositories;
using Domain.FlattenDtos;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
[Route("icons")]
public class IconController(
    IIconRepository iconRepository
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateIcon([FromBody] IconDto icon)
    {
        await iconRepository.CreateOrUpdateAsync(icon);
        return Ok();
    }

    [HttpGet(nameof(path))]
    public async Task<IActionResult> GetIcon([FromRoute] string path)
    {
        var icon = await iconRepository.FindAsync(path);
        if (icon is null)
        {
            return NotFound();
        }

        return File(icon.Body, "image/png");
    }
}