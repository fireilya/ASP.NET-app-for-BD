using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class SubtaskConverter : IEntityConverter<SubtaskDbo, SubtaskDto>
{
    public SubtaskDbo ToDbo(SubtaskDto dto) => new()
    {
        Id = dto.Id,
        AffectedEntityId = dto.AffectedEntityId,
        Name = dto.Name,
        Order = dto.Order,
        BaseEffectiveness = dto.BaseEffectiveness,
        IsUseCapacityTool = dto.IsUseCapacityTool,
    };

    public SubtaskDto ToDto(SubtaskDbo dbo) => new(
        dbo.Id,
        dbo.AffectedEntityId,
        dbo.Name,
        dbo.Order,
        dbo.BaseEffectiveness,
        dbo.IsUseCapacityTool
    );
}