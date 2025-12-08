using System.Threading.Tasks;
using AutoFixture;
using Dao.Entities;
using Dao.Repositories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestCore.IntegrationTests;

namespace Dao.IntegrationTests;

public class BriefInfoRepositoryTest : IntegrationTestBase
{
    private IBriefInfoRepository Repository => ServiceProvider.GetRequiredService<IBriefInfoRepository>();

    [Test]
    public async Task TestFind_WhenEntityExist()
    {
        // Arrange
        var briefInfoDbo = Fixture.Create<BriefInfoDbo>();
        await DataContext.InsertAsync(briefInfoDbo);

        // Act
        var briefInfoDto = await Repository.FindAsync(briefInfoDbo.Id);

        // Assert
        briefInfoDto.Should().NotBeNull();
        briefInfoDto.Should().BeEquivalentTo(briefInfoDbo);
    }
}