using GameService.Storages;

namespace GameService.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStorages(this IServiceCollection serviceCollection) => serviceCollection
       .AddSingleton<IActionAreaStorage, ActionAreaStorage>()
       .AddSingleton<IToolStorage, ToolStorage>();
}