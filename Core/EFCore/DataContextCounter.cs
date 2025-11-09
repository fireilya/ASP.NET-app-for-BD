using Core.Utilities;
using Microsoft.Extensions.Logging;

namespace Core.EFCore;

public static class DataContextCounter
{
    private const string CounterKey = "DataContextCounter";

    public static int GetContextNumber(ILogger logger)
    {
        var number = GlobalCounter.GetCountWithIncrement(CounterKey);
        logger.LogInformation("Создали контекст с номером {number}", number);
        return number;
    }
}