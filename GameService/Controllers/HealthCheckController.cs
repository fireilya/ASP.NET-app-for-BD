using Dao.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers;

[ApiController]
public class HealthCheckController(
    IHealthPhraseRepository healthPhraseRepository
) : ControllerBase
{
    [HttpGet("health")]
    public async Task<IActionResult> GetHealthStatus()
    {
        var healthPhrases = await healthPhraseRepository.SelectAllAsync();
        var phrasesWithLowFrequency = healthPhrases.OrderBy(x => x.ShowCount).Take(healthPhrases.Length / 3).ToArray();
        var phraseIndex = Random.Shared.Next(0, phrasesWithLowFrequency.Length);
        var phrase = phrasesWithLowFrequency[phraseIndex];

        await healthPhraseRepository.IncrementAsync(phrase.Id);

        return Ok(
            new
            {
                status = phrase.Text,
                timestamp = DateTimeOffset.Now,
            }
        );
    }
}