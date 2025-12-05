using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
public class HealthCheckController : ControllerBase
{
    [HttpGet("health")]
    public IActionResult GetHealthStatus()
    {
        return Ok(
            new
            {
                status = "Да пребудет с тобой Сила",
                timestamp = DateTimeOffset.Now,
            }
        );
    }
}