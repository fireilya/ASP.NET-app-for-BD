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

public class NonAffectiveInfoRepositoryTest : IntegrationTestBase
{
    private INonAffectiveInfoRepository Repository => ServiceProvider.GetRequiredService();
    [Test]
    public async Task TestRead_WhenEntityExist()
    {
        // Arrange
        var nonAffectiveInfoDbo = Fixture.Create();
        await DataContext.InsertAsync(nonAffectiveInfoDbo);
        // Act
        var nonAffectiveInfoDto = await Repository.ReadAsync(nonAffectiveInfoDbo.BriefInfoId, nonAffectiveInfoDbo.NonAffectiveInfoType);
        // Assert
        nonAffectiveInfoDto.Should().NotBeNull();
        nonAffectiveInfoDto.Should().BeEquivalentTo(nonAffectiveInfoDbo);
    }
}