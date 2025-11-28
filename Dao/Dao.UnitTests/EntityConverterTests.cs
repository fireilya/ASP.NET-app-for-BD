using System;
using System.Collections.Generic;
using System.Linq;
using Core.EFCore;
using Dao.Converters;
using FluentAssertions;
using NUnit.Framework;
using TestCore.Common;
using TestCore.UnitTests;

namespace Dao.UnitTests;

public class EntityConverterTests : UnitTestBase
{
    [TestCaseSource(nameof(GetConverters))]
    public void TestToDbo(Type converterType)
    {
        // Arrange
        var converter = Activator.CreateInstance(converterType);

        var toDboMethod = converterType.GetMethod("ToDbo");
        toDboMethod.Should().NotBeNull("У конвертера должен быть метод ToDbo");

        var toDboMethodParameters = toDboMethod.GetParameters();
        toDboMethodParameters.Should().HaveCount(1, "У метода ToDbo должен быть только один входной параметр - Dto");

        var dtoType = toDboMethodParameters[0].ParameterType;
        var dto = Fixture.Create(dtoType);

        // Act
        var dbo = toDboMethod.Invoke(converter, [dto]);

        // Assert
        dbo.Should().BeEquivalentTo(dto);
    }

    [TestCaseSource(nameof(GetConverters))]
    public void TestToDto(Type converterType)
    {
        // Arrange
        var converter = Activator.CreateInstance(converterType);

        var toDtoMethod = converterType.GetMethod("ToDto");
        toDtoMethod.Should().NotBeNull("У конвертера должен быть метод ToDto");

        var toDtoMethodParameters = toDtoMethod.GetParameters();
        toDtoMethodParameters.Should().HaveCount(1, "У метода ToDto должен быть только один входной параметр - Dbo");

        var dboType = toDtoMethodParameters[0].ParameterType;
        var dbo = Fixture.Create(dboType);

        // Act
        var dto = toDtoMethod.Invoke(converter, [dbo]);

        // Assert
        dto.Should().BeEquivalentTo(dbo);
    }

    private static IEnumerable<TestCaseData> GetConverters()
    {
        var daoAssembly = typeof(IDistrictConverter).Assembly;
        var entityConvererInterfaceType = typeof(IEntityConverter<,>);
        var daoConverters = daoAssembly.GetTypes()
           .Where(type => type.GetInterfaces().Any(@interface => @interface.Name == entityConvererInterfaceType.Name))
           .Where(type => type.IsClass)
           .ToArray();

        foreach (var daoConverter in daoConverters)
        {
            yield return new TestCaseData(daoConverter).SetName(daoConverter.Name);
        }
    }
}