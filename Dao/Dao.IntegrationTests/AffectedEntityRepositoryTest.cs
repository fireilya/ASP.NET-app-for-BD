using System.Threading.Tasks;
using AutoFixture;
using Dao.Entities;
using Dao.Repositories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestCore.IntegrationTests;

namespace Dao.IntegrationTests;

public class AffectedEntityRepositoryTest : IntegrationTestBase
{
    private IAffectedEntityRepository Repository => ServiceProvider.GetRequiredService<IAffectedEntityRepository>();

    [Test]
    public async Task TestFind_WhenEntityExist()
    {
        // Arrange
        var affectedEntityDbo = Fixture.Build<AffectedEntityDbo>().Create();
        await DataContext.InsertAsync(affectedEntityDbo);

        // Act
        var affectedEntityDto = await Repository.FindAsync(affectedEntityDbo.Id);

        // Assert
        affectedEntityDto.Should().NotBeNull();
        affectedEntityDto.Should().BeEquivalentTo(affectedEntityDbo);
    }
}