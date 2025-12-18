using System;
using System.Linq;
using System.Text.Json;
using AutoFixture;
using Domain.Scheduler;
using NUnit.Framework;
using TestCore.UnitTests;

namespace GameService.UnitTests;

public class ActionAreaStorageTest : UnitTestBase
{
    [Test]
    public void SerializationTest()
    {
        var actionArea = new ActionArea(
            Guid.NewGuid(),
            Guid.NewGuid().ToString(),
            Fixture.Create<string>(),
            [CreateLocation(), CreateLocation()]
        );
        var stringifyActionArea = JsonSerializer.Serialize(actionArea);
        TestContext.Out.WriteLine(stringifyActionArea);
    }

    private Location CreateLocation(int taskCount = 2)
    {
        return new Location(
            Guid.NewGuid(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            CreateGameTasks(taskCount),
            Fixture.Create<Risk>()
        );
    }

    private GameTask[] CreateGameTasks(int count = 2)
    {
        return Enumerable.Repeat(CreateGameTask, count).Select(x => x()).ToArray();

        GameTask CreateGameTask()
        {
            return new GameTask(
                Guid.NewGuid(),
                Guid.NewGuid().ToString(),
                Fixture.Create<int>(),
                Fixture.Create<short>(),
                [
                    Fixture.Build<CapacitySubtask>().Without(x => x.PreviousSubtask).Without(x => x.Parent).Create(),
                    Fixture.Build<ProcessSubtask>().Without(x => x.PreviousSubtask).Without(x => x.Parent).Create(),
                ],
                Fixture.Create<bool>()
            );
        }
    }
}