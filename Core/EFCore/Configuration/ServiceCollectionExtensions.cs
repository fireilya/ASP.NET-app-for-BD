using System;
using Core.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.EFCore.Configuration;

public static class ServiceCollectionExtensions
{
    private const int PoolSize = 128;

    public static IServiceCollection AddNpg(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDbContextOptionsConfigurator, NpgDbContextOptionsConfigurator>()
           .AddOptionsWithValidation<DataContextOptions>()
           .AddDbContextPool<DataContext>(
                (provider, optionsBuilder) =>
                    provider.GetRequiredService<IDbContextOptionsConfigurator>().Configure(optionsBuilder),
                PoolSize
            )
           .AddPooledDbContextFactory<DataContext>(
                _ => { }, // Он почему-то два конфигурируется, так вроде работает
                PoolSize
            )
           .AddScoped<IDataContext>(x => x.GetRequiredService<DataContext>())
           .AddSingleton<IDataContextFactory, DataContextFactory>()
           .AddSingleton<ISingletonDataContext, SingletonDataContext>()
           .AddSingleton<Lazy<INpgOptionsConfigurator?>>(x =>
                new Lazy<INpgOptionsConfigurator?>(x.GetService<INpgOptionsConfigurator>())
            );

        return serviceCollection;
    }
}