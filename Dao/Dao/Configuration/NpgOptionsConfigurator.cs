using System.Linq;
using System.Reflection;
using Core.Common.Linq;
using Core.EFCore.Configuration;
using Domain.Enumerations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Dao.Configuration;

public class NpgOptionsConfigurator : INpgOptionsConfigurator
{
    public void Configure(NpgsqlDbContextOptionsBuilder builder)
    {
        var domainAssembly = typeof(StorageEnumerationAttribute).Assembly;
        domainAssembly.GetTypes()
           .Where(type => type.IsEnum)
           .Select(type => (EnumType: type, EnumAttribute: type.GetCustomAttribute<StorageEnumerationAttribute>()))
           .Where(pair => pair.EnumAttribute != null)
           .Foreach(pair => builder.MapEnum(pair.EnumType, enumName: pair.EnumAttribute?.NameInStorage));
    }
}