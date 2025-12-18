using System;
using System.Linq;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface IRiskRepository : IRepository
{
    Task CreateAsync(RiskDto dto);
    Task<RiskDto?> FindAsync(Guid id);
    Task UpdateAsync(RiskDto dto);
    Task DeleteAsync(RiskDto dto);
    Task<RiskDto> FindRiskForLocationAsync(Guid locationId);
}

public class RiskRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<RiskDbo, RiskDto> converter
) : RepositoryBase<RiskDbo, RiskDto, Guid>(dataContext, converter, x => x.Id), IRiskRepository
{
    public async Task<RiskDto> FindRiskForLocationAsync(Guid locationId)
    {
        return Converter.ToDto(
            await DataContext.ExecuteQueryAsync<RiskDbo, RiskDbo>(query => query
                .Where(x => x.LocationId == locationId)
                .FirstAsync()));
    }
}