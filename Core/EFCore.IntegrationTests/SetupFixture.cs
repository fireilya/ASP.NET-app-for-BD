using Core.EFCore.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCore.IntegrationTests;

namespace Core.EFCore.IntegrationTests;

public class SetupFixture : SetupFixtureBase
{
    protected override void CustomizeServiceCollection(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDbContextModelConfigurator, DbContextModelConfigurator>();
    }
}