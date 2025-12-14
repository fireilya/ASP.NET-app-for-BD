using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class SubtaskCapacityToolConverter : IEntityConverter<SubtaskCapacityToolDbo, SubtaskCapacityToolDto>
{
    public SubtaskCapacityToolDbo ToDbo(SubtaskCapacityToolDto dto) => new()
    {
        Id = dto.Id,
        ResourceId = dto.ResourceId,
        SubtaskId = dto.SubtaskId,
        Capacity = dto.Capacity,
    };

    public SubtaskCapacityToolDto ToDto(SubtaskCapacityToolDbo dbo) => new()
    {
        Id = dbo.Id,
        ResourceId = dbo.ResourceId,
        SubtaskId = dbo.SubtaskId,
        Capacity = dbo.Capacity,
    };
}