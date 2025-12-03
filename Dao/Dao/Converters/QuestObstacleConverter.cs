using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestObstacleConverter : IEntityConverter<QuestObstacleDbo, QuestObstacleDto>
{
    public QuestObstacleDbo ToDbo(QuestObstacleDto dto) => new()
    {
        Id = dto.Id,
        ResearchAreaId = dto.ResearchAreaId,
        Name = dto.Name,
        Description = dto.Description,
        TimeDelayInMinutes = dto.TimeDelayInMinutes,
        MaxInstance = dto.MaxInstance,
        PathToIcon = dto.PathToIcon,
    };

    public QuestObstacleDto ToDto(QuestObstacleDbo dbo) => new()
    {
        Id = dbo.Id,
        ResearchAreaId = dbo.ResearchAreaId,
        Name = dbo.Name,
        Description = dbo.Description,
        TimeDelayInMinutes = dbo.TimeDelayInMinutes,
        MaxInstance = dbo.MaxInstance,
        PathToIcon = dbo.PathToIcon,
    };
}