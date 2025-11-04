using Microsoft.EntityFrameworkCore;

namespace Core.EFCore;

public interface IDbContextConfigurator
{
    void Configure(DbContextOptionsBuilder optionsBuilder);
}