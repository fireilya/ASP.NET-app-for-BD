using System;
using System.Threading.Tasks;
using AutoFixture;
using Dao.Entities;
using Dao.Repositories;
using Domain.FlattenDtos;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestCore.Common;
using TestCore.IntegrationTests;

namespace Dao.IntegrationTests;

public class GameEventRepositoryTest : IntegrationTestBase
{
    private IGameEventRepository GameEventRepository => ServiceProvider.GetRequiredService<IGameEventRepository>();

    [Test]
    public async Task TestCreate()
    {
        // Arrange
        var gameEventDto = Fixture.Build<GameEventDto>()
           .With(x => x.EventData, Fixture.CreateJsonString())
           .Create();

        // Act
        await GameEventRepository.CreateAsync(gameEventDto);

        // Assert
        var foundEntity = await DataContext.FindAsync<GameEventDbo, Guid>(gameEventDto.Id);
        foundEntity.Should().NotBeNull();
        foundEntity.Should().BeEquivalentTo(gameEventDto);
    }
}