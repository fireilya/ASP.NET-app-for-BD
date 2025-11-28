using Core.EFCore.Configuration;
using Dao.Entities;
using Domain.Enumerations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Dao.Configuration;

public class NpgOptionsConfigurator : INpgOptionsConfigurator
{
    public void Configure(NpgsqlDbContextOptionsBuilder builder)
    {
        builder.MapEnum<GameEventType>(enumName: EnumNames.GameEventType);
        builder.MapEnum<GameScreenMode>(enumName: EnumNames.GameScreenMode);
    }
}