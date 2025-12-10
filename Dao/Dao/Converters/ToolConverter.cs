using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class ToolConverter : IEntityConverter<ToolDbo, ToolDto>
{
    public ToolDbo ToDbo(ToolDto dto) => new()
    {
        Id = dto.Id,
        ResourceId = dto.ResourceId,
        PathToIcon = dto.PathToIcon,
    };

    public ToolDto ToDto(ToolDbo dbo) => new()
    {
        Id = dbo.Id,
        ResourceId = dbo.ResourceId,
        PathToIcon = dbo.PathToIcon,
    };
}