using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class SubtaskToolConverter : IEntityConverter<SubtaskToolDbo, SubtaskToolDto>
{
    public SubtaskToolDbo ToDbo(SubtaskToolDto dto) => new()
    {
        Id = dto.Id,
        ResourceId = dto.ResourceId,
        SubtaskId = dto.SubtaskId,
    };

    public SubtaskToolDto ToDto(SubtaskToolDbo dbo) => new()
    {
        Id = dbo.Id,
        ResourceId = dbo.ResourceId,
        SubtaskId = dbo.SubtaskId,
    };
}