using Core.EFCore.Configuration;
using Dao.Converters;
using Dao.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dao.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDao(this IServiceCollection serviceCollection) =>
        serviceCollection.AddNpg().AddDaoServices();

    public static IServiceCollection AddDaoServices(this IServiceCollection serviceCollection) => serviceCollection
       .AddSingleton<IDbContextModelConfigurator, DbContextModelConfigurator>()
       .AddSingleton<INpgOptionsConfigurator, NpgOptionsConfigurator>()
       .AddSingleton<IGameEventConverter, GameEventConverter>()
       .AddSingleton<IGameEventRepository, GameEventRepository>()
       .AddSingleton<IDistrictConverter, DistrictConverter>()
       .AddSingleton<IDistrictRepository, DistrictRepository>()
       .AddSingleton<IPlayerSettingsConverter, PlayerSettingsConverter>()
       .AddSingleton<IPlayerSettingsRepository, PlayerSettingsRepository>();
}