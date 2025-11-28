using System;
using System.Threading.Tasks;
using AutoFixture;
using Core.EFCore;
using Dao.Entities;
using Dao.Repositories;
using Domain.FlattenDtos;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestCore.IntegrationTests;

namespace Dao.IntegrationTests;

public class PlayerSettingsRepositoryTest : IntegrationTestBase
{
    private IPlayerSettingsRepository PlayerSettingsRepository =>
        ServiceProvider.GetRequiredService<IPlayerSettingsRepository>();

    [Test]
    public async Task TestCreate()
    {
        // Arrange
        var playerSettingsDto = Fixture.Build<PlayerSettingsDto>().Create();

        // Act
        await PlayerSettingsRepository.CreateAsync(playerSettingsDto);

        // Assert
        var foundEntity = await DataContext.FindAsync<PlayerSettingsDbo, Guid>(playerSettingsDto.Id);
        foundEntity.Should().NotBeNull();
        foundEntity.Should().BeEquivalentTo(playerSettingsDto);
    }

    [Test]
    public async Task TestReadByPlayer_WhenExist()
    {
        // Arrange
        var playerSettingsDbo = Fixture.Build<PlayerSettingsDbo>().Create();
        await DataContext.InsertAsync(playerSettingsDbo);

        // Act
        var foundDto = await PlayerSettingsRepository.ReadByPlayerAsync(playerSettingsDbo.PlayerId);

        // Assert
        foundDto.Should().NotBeNull();
        foundDto.Should().BeEquivalentTo(playerSettingsDbo);
    }

    [Test]
    public async Task TestReadByPlayer_WhenNotExist()
    {
        // Act | Assert
        await PlayerSettingsRepository.Invoking(x => x.ReadByPlayerAsync(Guid.NewGuid()))
           .Should()
           .ThrowAsync<EntityNotFoundException>();
    }

    [Test]
    public async Task TestUpdate()
    {
        // Arrange
        var playerSettingsDbo = Fixture.Build<PlayerSettingsDbo>().Create();
        var newPlayerSettings = Fixture.Build<PlayerSettingsDto>()
           .With(x => x.Id, playerSettingsDbo.Id)
           .Create();
        await DataContext.InsertAsync(playerSettingsDbo);

        // Act
        await PlayerSettingsRepository.UpdateAsync(newPlayerSettings);

        // Assert
        var foundEntity = await DataContext.FindAsync<PlayerSettingsDbo, Guid>(playerSettingsDbo.Id);
        foundEntity.Should().NotBeNull();
        foundEntity.Should().BeEquivalentTo(newPlayerSettings);
    }
}