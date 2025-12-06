using System;
using System.Linq;
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

public class HealthPhraseRepositoryTest : IntegrationTestBase
{
    private IHealthPhraseRepository Repository => ServiceProvider.GetRequiredService<IHealthPhraseRepository>();

    private IEntityConverter<HealthPhraseDbo, HealthPhraseDto> Converter =>
        ServiceProvider.GetRequiredService<IEntityConverter<HealthPhraseDbo, HealthPhraseDto>>();

    [Test]
    public async Task TestSelectAll()
    {
        // Arrange
        const int phraseCount = 7;
        var healthPhraseDbos = Fixture.CreateMany<HealthPhraseDbo>(phraseCount).ToArray();
        await DataContext.InsertRangeAsync(healthPhraseDbos);

        // Act
        var healthPhraseDtos = await Repository.SelectAllAsync();

        // Assert
        healthPhraseDtos.Should().HaveCountGreaterThanOrEqualTo(phraseCount);
        foreach (var healthPhraseDbo in healthPhraseDbos)
        {
            healthPhraseDtos.Should().ContainEquivalentOf(Converter.ToDto(healthPhraseDbo));
        }
    }

    [Test]
    public async Task TestIncrement()
    {
        // Arrange
        var healthPhraseDbo1 = Fixture.Create<HealthPhraseDbo>();
        var healthPhraseDbo2 = Fixture.Create<HealthPhraseDbo>();
        await DataContext.InsertRangeAsync(healthPhraseDbo1, healthPhraseDbo2);

        // Act
        await Repository.IncrementAsync(healthPhraseDbo1.Id);

        // Assert
        var foundHealthPhraseDbo1 = await DataContext.FindAsync<HealthPhraseDbo, Guid>(healthPhraseDbo1.Id);
        foundHealthPhraseDbo1.Should().BeEquivalentTo(healthPhraseDbo1, options => options.Excluding(h => h.ShowCount));
        foundHealthPhraseDbo1.ShowCount.Should().Be(healthPhraseDbo1.ShowCount + 1);

        var foundHealthPhraseDbo2 = await DataContext.FindAsync<HealthPhraseDbo, Guid>(healthPhraseDbo2.Id);
        foundHealthPhraseDbo2.Should().BeEquivalentTo(healthPhraseDbo2);
    }
}