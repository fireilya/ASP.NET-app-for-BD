using Core.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.EFCore.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNpg(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDbContextConfigurator, NpgDbContextConfigurator>();
        serviceCollection.AddOptionsWithValidation<DataContextOptions>()
           .AddDbContextPool<DataContext>((provider, optionsBuilder) =>
                provider.GetRequiredService<IDbContextConfigurator>().Configure(optionsBuilder)
            );

        return serviceCollection;
    }
}