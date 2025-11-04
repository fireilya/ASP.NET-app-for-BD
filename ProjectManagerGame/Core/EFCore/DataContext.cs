using Core.Utilities;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.EFCore;

public class DataContext(
    IDbContextConfigurator configurator,
    ILogger<DataContext> logger,
    DbContextOptions dbContextOptions
) : DbContext(dbContextOptions)
{
    private const string CounterKey = "DataContextCounter";
    private readonly int currentContextNumber = GlobalCounter.GetCountWithIncrement(CounterKey);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        logger.LogInformation("Context: {contextNumber} Configuring data context", currentContextNumber);
        configurator.Configure(new DbContextOptionsBuilder());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        logger.LogInformation("Context: {contextNumber} Data context model creating", currentContextNumber);
        modelBuilder.Entity<TestEntity>();
    }
}