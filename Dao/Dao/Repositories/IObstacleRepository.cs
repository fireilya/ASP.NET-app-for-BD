using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IObstacleRepository : IRepository
{
    Task CreateAsync(ObstacleDto dto);
    Task<ObstacleDto?> FindAsync(Guid id);
    Task UpdateAsync(ObstacleDto dto);
    Task DeleteAsync(ObstacleDto dto);
}

public class ObstacleRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<ObstacleDbo, ObstacleDto> converter
) : RepositoryBase<ObstacleDbo, ObstacleDto, Guid>(dataContext, converter, x => x.Id),
    IObstacleRepository;