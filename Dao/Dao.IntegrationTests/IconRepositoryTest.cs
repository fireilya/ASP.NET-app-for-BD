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

public class IconRepositoryTest : IntegrationTestBase
{
    private IIconRepository Repository => ServiceProvider.GetRequiredService<IIconRepository>();

    [Test]
    public async Task TestCreateOrUpdate_Create()
    {
        // Arrange
        var dto = Fixture.Create<IconDto>();

        // Act
        await Repository.CreateOrUpdateAsync(dto);

        // Assert
        var foundIcon = await DataContext.FindAsync<IconDbo, string>(dto.Id);
        foundIcon.Should().NotBeNull();
        foundIcon.Should().BeEquivalentTo(dto);
    }

    [Test]
    public async Task TestCreateOrUpdate_Update()
    {
        // Arrange
        var dbo = Fixture.Create<IconDbo>();
        var dto = Fixture.Build<IconDto>().With(x => x.Id, dbo.Id).Create();
        await DataContext.InsertAsync(dbo);

        // Act
        await Repository.CreateOrUpdateAsync(dto);

        // Assert
        var foundIcon = await DataContext.FindAsync<IconDbo, string>(dto.Id);
        foundIcon.Should().NotBeNull();
        foundIcon.Should().BeEquivalentTo(dto);
    }
}