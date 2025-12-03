using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestObstacleConverter : IEntityConverter<QuestObstacleDbo, QuestObstacleDto>
{
    public QuestObstacleDbo ToDbo(QuestObstacleDto dto) => new()
    {
        Id = dto.Id,
        ObstacleId = dto.ObstacleId,
        ResearchAreaId = dto.ResearchAreaId,
    };

    public QuestObstacleDto ToDto(QuestObstacleDbo dbo) => new()
    {
        Id = dbo.Id,
        ObstacleId = dbo.ObstacleId,
        ResearchAreaId = dbo.ResearchAreaId,
    };
}