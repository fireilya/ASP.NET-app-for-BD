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

    public ObstacleDto ToDto(ObstacleDbo dbo) => new()
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