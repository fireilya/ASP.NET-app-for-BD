using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class ObstacleConverter : IEntityConverter<ObstacleDbo, ObstacleDto>
{
    public ObstacleDbo ToDbo(ObstacleDto dto) => new()
    {
        Id = dto.Id,
        ResearchAreaId = dto.ResearchAreaId,
        Name = dto.Name,
        Description = dto.Description,
        TimeDelayInMinutes = dto.TimeDelayInMinutes,
        MaxInstance = dto.MaxInstance,
        PathToIcon = dto.PathToIcon,
    };

    public ObstacleDto ToDto(ObstacleDbo dbo) => new(
        dbo.Id,
        dbo.ResearchAreaId,
        dbo.Name,
        dbo.Description,
        dbo.TimeDelayInMinutes,
        dbo.MaxInstance,
        dbo.PathToIcon
    );
}