using AutoFixture;
using NUnit.Framework;

namespace TestCore.UnitTests;

[TestFixture]
[Category("UnitTests")]
public abstract class UnitTestBase
{
    protected Fixture Fixture { get; } = new();
}