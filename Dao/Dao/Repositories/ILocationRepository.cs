using System;
using System.Linq;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface ILocationRepository : IRepository
{
    Task CreateAsync(LocationDto dto);
    Task<LocationDto?> FindAsync(Guid id);
    Task UpdateAsync(LocationDto dto);
    Task DeleteAsync(LocationDto dto);
    
    Task<LocationDto[]> FindAllForActionAreaAsync(Guid actionAreaId);
}

public class LocationRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<LocationDbo, LocationDto> converter
) : RepositoryBase<LocationDbo, LocationDto, Guid>(dataContext, converter, x => x.Id), ILocationRepository
{
    public async Task<LocationDto[]> FindAllForActionAreaAsync(Guid actionAreaId)
    {
        var locations = await DataContext.ExecuteQueryAsync<LocationDbo, LocationDbo[]>(
            query => query
                .Where(x => x.ActionAreaId == actionAreaId)
                .ToArrayAsync());
        
        return Converter.ToDto(locations);
    }
}