using System.Linq;
using Core.Common.Linq;
using Core.EFCore;
using Core.EFCore.Configuration;
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
       .AddConverters()
       .AddSingleton<IGameEventRepository, GameEventRepository>()
       .AddSingleton<IDistrictRepository, DistrictRepository>()
       .AddSingleton<IPlayerSettingsRepository, PlayerSettingsRepository>();

    private static IServiceCollection AddConverters(this IServiceCollection serviceCollection)
    {
        var daoAssembly = DaoAssemblyHelper.GetDaoAssembly();
        var entityConvererInterfaceName = typeof(IEntityConverter<,>).Name;

        daoAssembly.GetTypes()
           .Select(type => (
                Implementation: type,
                Interface: type.GetInterfaces()
                   .FirstOrDefault(@interface => @interface.Name == entityConvererInterfaceName))
            )
           .Where(pair => pair.Interface != null)
           .Where(pair => pair.Implementation.IsClass)
           .Foreach(pair => serviceCollection.AddSingleton(pair.Interface!, pair.Implementation));

        return serviceCollection;
    }
}