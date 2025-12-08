using System;
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
    private IAffectedEntityRepository Repository => ServiceProvider.GetRequiredService();
    [Test]
    public async Task TestRead_WhenEntityExist()
    {
        // Arrange
        var affectedEntityDbo = Fixture.Create();
        await DataContext.InsertAsync(affectedEntityDbo);
        
        // Act
        var affectedEntityDto = await Repository.ReadAsync(affectedEntityDbo.Id);
        
        // Assert
        affectedEntityDto.Should().NotBeNull();
        affectedEntityDto.Should().BeEquivalentTo(affectedEntityDbo);
    }
}