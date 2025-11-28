using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Core.EFCore.Configuration;

public interface INpgOptionsConfigurator
{
    void Configure(NpgsqlDbContextOptionsBuilder builder);
}