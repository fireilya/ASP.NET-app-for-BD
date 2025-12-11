using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface ILocationRepository : IRepository
{
    Task CreateAsync(LocationDto dto);
    Task<LocationDto?> FindAsync(Guid id);
    Task UpdateAsync(LocationDto dto);
    Task DeleteAsync(LocationDto dto);
}

public class LocationRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<LocationDbo, LocationDto> converter
) : RepositoryBase<LocationDbo, LocationDto, Guid>(dataContext, converter, x => x.Id), ILocationRepository;