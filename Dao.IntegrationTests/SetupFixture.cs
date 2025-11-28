using Dao.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCore.IntegrationTests;

namespace Dao.IntegrationTests;

public class SetupFixture : SetupFixtureBase
{
    protected override void CustomizeServiceCollection(IServiceCollection serviceCollection)
    {
        serviceCollection.AddDaoServices();;
    }
}