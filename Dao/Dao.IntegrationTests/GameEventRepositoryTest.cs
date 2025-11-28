using System;
using System.Linq;
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

    [Test]
    public async Task TestFind()
    {
        // Arrange
        var gameEventDbo = Fixture.Build<GameEventDbo>()
           .With(x => x.EventData, Fixture.CreateJsonString())
           .Create();
        await DataContext.InsertAsync(gameEventDbo);

        // Act
        var foundDto = await GameEventRepository.FindAsync(gameEventDbo.Id);

        // Assert
        foundDto.Should().NotBeNull();
        foundDto.Should().BeEquivalentTo(gameEventDbo);
    }

    [Test]
    public async Task TestSelect()
    {
        // Arrange
        var gameEventDbos = Fixture.Build<GameEventDbo>()
           .With(x => x.EventData, Fixture.CreateJsonString())
           .CreateMany(17)
           .ToArray();
        await DataContext.InsertRangeAsync(gameEventDbos);

        var gameEventsToSelect = gameEventDbos.Skip(6).Take(5).ToArray();
        var idsToSelect = gameEventsToSelect.Select(x => x.Id).ToArray();

        // Act
        var selectedDtos = await GameEventRepository.SelectAsync(idsToSelect);

        // Assert
        selectedDtos.Should().HaveCount(gameEventsToSelect.Length);
        selectedDtos.Should().BeEquivalentTo(gameEventsToSelect);
    }

    [Test]
    public async Task TestUpdate()
    {
        // Arrange
        var gameEventDbo = Fixture.Build<GameEventDbo>()
           .With(x => x.EventData, Fixture.CreateJsonString())
           .Create();
        var newGameEvent = Fixture.Build<GameEventDto>()
           .With(x => x.Id, gameEventDbo.Id)
           .With(x => x.EventData, Fixture.CreateJsonString())
           .Create();
        await DataContext.InsertAsync(gameEventDbo);

        // Act
        await GameEventRepository.UpdateAsync(newGameEvent);

        // Assert
        var foundEntity = await DataContext.FindAsync<GameEventDbo, Guid>(gameEventDbo.Id);
        foundEntity.Should().NotBeNull();
        foundEntity.Should().BeEquivalentTo(newGameEvent);
    }

    [Test]
    public async Task TestDelete()
    {
        // Arrange
        var gameEventDbo = Fixture.Build<GameEventDbo>()
           .With(x => x.EventData, Fixture.CreateJsonString())
           .Create();
        var gameEventDto = Fixture.Build<GameEventDto>()
           .With(x => x.Id, gameEventDbo.Id)
           .With(x => x.EventData, Fixture.CreateJsonString())
           .Create();
        await DataContext.InsertAsync(gameEventDbo);

        // Act
        await GameEventRepository.DeleteAsync(gameEventDto);

        // Assert
        var foundEntity = await DataContext.FindAsync<GameEventDbo, Guid>(gameEventDbo.Id);
        foundEntity.Should().BeNull();
    }

    [Test]
    public async Task TestDeleteByIds()
    {
        // Arrange
        var gameEventDbos = Fixture.Build<GameEventDbo>()
           .With(x => x.EventData, Fixture.CreateJsonString())
           .CreateMany(17)
           .ToArray();
        await DataContext.InsertRangeAsync(gameEventDbos);

        var gameEventsToDelete = gameEventDbos.Skip(6).Take(5).ToArray();
        var idsToDelete = gameEventsToDelete.Select(x => x.Id).ToArray();

        // Act
        await GameEventRepository.DeleteAsync(idsToDelete);

        // Assert
        var selectedEntities = await DataContext.SelectAsync<GameEventDbo, Guid>(
            x => x.Id,
            gameEventDbos.Select(x => x.Id).ToArray()
        );
        selectedEntities.Should().HaveCount(gameEventDbos.Length - gameEventsToDelete.Length);
        selectedEntities.Should().BeEquivalentTo(gameEventDbos.Except(gameEventsToDelete));
    }
}