using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IQuestObstacleRepository : IRepository
{
    Task CreateAsync(QuestObstacleDto dto);
    Task<QuestObstacleDto?> FindAsync(Guid id);
    Task UpdateAsync(QuestObstacleDto dto);
    Task DeleteAsync(QuestObstacleDto dto);
}

public class QuestObstacleRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestObstacleDbo, QuestObstacleDto> converter
) : RepositoryBase<QuestObstacleDbo, QuestObstacleDto, Guid>(dataContext, converter, x => x.Id),
    IQuestObstacleRepository;