using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Core.EFCore.Configuration;

public class NpgDbContextOptionsConfigurator(
    IOptions<DataContextOptions> options,
    ILogger<DataContext> logger,
    Lazy<INpgOptionsConfigurator?> npgOptionConfigurator
) : IDbContextOptionsConfigurator
{
    public void Configure(DbContextOptionsBuilder optionsBuilder)
    {
        var dataContextOptions = options.Value;
        optionsBuilder.UseNpgsql(
            dataContextOptions.ConnectionString,
            optBuilder => npgOptionConfigurator.Value?.Configure(optBuilder)
        );
        if (dataContextOptions.EnableSensitiveDataLogging)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        optionsBuilder.UseLoggerFactory(NullLoggerFactory.Instance);
        optionsBuilder.LogTo(
            (_, _) => true,
            x => logger.Log(x.LogLevel, "{dbLog}", x.ToString())
        );
    }
}