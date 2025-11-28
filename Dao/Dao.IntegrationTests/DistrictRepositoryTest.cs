using System;
using System.Threading.Tasks;
using AutoFixture;
using Dao.Entities;
using Dao.Repositories;
using Domain.FlattenDtos;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestCore.IntegrationTests;

namespace Dao.IntegrationTests;

public class DistrictRepositoryTest : IntegrationTestBase
{
    private IDistrictRepository Repository => ServiceProvider.GetRequiredService<IDistrictRepository>();

    [Test]
    public async Task TestCreate()
    {
        // Arrange
        var districtDto = Fixture.Build<DistrictDto>().Create();

        // Act
        await Repository.CreateAsync(districtDto);

        // Assert
        var foundEntity = await DataContext.FindAsync<DistrictDbo, Guid>(districtDto.Id);
        foundEntity.Should().NotBeNull();
        foundEntity.Should().BeEquivalentTo(districtDto);
    }

    [Test]
    public async Task TestFind_WhenExist()
    {
        // Arrange
        var districtDbo = Fixture.Build<DistrictDbo>().Create();
        await DataContext.InsertAsync(districtDbo);

        // Act
        var foundDto = await Repository.FindAsync(districtDbo.Id);

        // Assert
        foundDto.Should().NotBeNull();
        foundDto.Should().BeEquivalentTo(districtDbo);
    }

    [Test]
    public async Task TestFind_WhenNotExist()
    {
        // Act
        var foundDto = await Repository.FindAsync(Guid.NewGuid());

        // Assert
        foundDto.Should().BeNull();
    }

    [Test]
    public async Task TestUpdate()
    {
        // Arrange
        var districtDbo = Fixture.Build<DistrictDbo>().Create();
        var newDistrict = Fixture.Build<DistrictDto>()
           .With(x => x.Id, districtDbo.Id)
           .Create();
        await DataContext.InsertAsync(districtDbo);

        // Act
        await Repository.UpdateAsync(newDistrict);

        // Assert
        var foundEntity = await DataContext.FindAsync<DistrictDbo, Guid>(districtDbo.Id);
        foundEntity.Should().NotBeNull();
        foundEntity.Should().BeEquivalentTo(newDistrict);
    }

    [Test]
    public async Task TestDelete()
    {
        // Arrange
        var districtDbo = Fixture.Build<DistrictDbo>().Create();
        var districtDto = Fixture.Build<DistrictDto>()
           .With(x => x.Id, districtDbo.Id)
           .Create();
        await DataContext.InsertAsync(districtDbo);

        // Act
        await Repository.DeleteAsync(districtDto);

        // Assert
        var foundEntity = await DataContext.FindAsync<DistrictDbo, Guid>(districtDbo.Id);
        foundEntity.Should().BeNull();
    }
}