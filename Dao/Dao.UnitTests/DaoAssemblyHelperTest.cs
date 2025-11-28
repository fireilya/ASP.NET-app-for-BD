using Dao.Configuration;
using FluentAssertions;
using NUnit.Framework;
using TestCore.UnitTests;

namespace Dao.UnitTests;

public class DaoAssemblyHelperTest : UnitTestBase
{
    [Test]
    public void TestGetDaoAssembly()
    {
        // Act
        var daoAssembly = DaoAssemblyHelper.GetDaoAssembly();

        // Assert
        daoAssembly.FullName.Should().Be("Dao, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
    }
}