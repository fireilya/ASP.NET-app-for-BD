using System;
using System.Collections.Generic;
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
            CreateString(20),
            CreateString(20),
            [CreateLocation(), CreateLocation()]
        );
        var stringifyActionArea = JsonSerializer.Serialize(actionArea);
        TestContext.Out.WriteLine(stringifyActionArea);
    }

    private Location CreateLocation(int taskCount = 2)
    {
        return new Location(
            Guid.NewGuid(),
            CreateString(20),
            CreateString(20),
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
                CreateString(20),
                Fixture.Create<int>(),
                Fixture.Create<short>(),
                [
                    new CapacitySubtask(
                        Guid.NewGuid(),
                        CreateString(20),
                        Fixture.Create<int>(),
                        Fixture.Create<bool>(),
                        Fixture.Create<int>(),
                        Fixture.Create<Dictionary<Guid, short>>()
                    ),
                    new ProcessSubtask(
                        Guid.NewGuid(),
                        CreateString(20),
                        Fixture.Create<int>(),
                        Fixture.Create<bool>(),
                        Guid.NewGuid()
                    ),
                ],
                Fixture.Create<bool>()
            );
        }
    }

    private string CreateString(int lengthLimit) => Fixture.Create<string>()[..lengthLimit];
}