using System.Threading.Tasks;
using AutoFixture;
using Dao.Entities;
using Dao.Repositories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TestCore.IntegrationTests;

namespace Dao.IntegrationTests;

public class QuestionRepositoryTest : IntegrationTestBase
{
    private IQuestionRepository Repository => ServiceProvider.GetRequiredService<IQuestionRepository>();

    [Test]
    public async Task TestRead_WhenEntityExist()
    {
        // Arrange
        var questionDbo = Fixture.Create<QuestionDbo>();
        await DataContext.InsertAsync(questionDbo);

        // Act
        var questionDto = await Repository.ReadAsync(questionDbo.Id);

        // Assert
        questionDto.Should().NotBeNull();
        questionDto.Should().BeEquivalentTo(questionDbo);
    }
}