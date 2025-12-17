using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class TaskConverter : IEntityConverter<TaskDbo, TaskDto>
{
    public TaskDbo ToDbo(TaskDto dto) => new()
    {
        Id = dto.Id,
        AffectedEntityId = dto.AffectedEntityId,
        LocationId = dto.LocationId,
        Name = dto.Name,
        Target = dto.Target,
        DayLimit = dto.DayLimit,
    };

    public TaskDto ToDto(TaskDbo dbo) =>
        new(dbo.Id, dbo.AffectedEntityId, dbo.LocationId, dbo.Name, dbo.Target, dbo.DayLimit);
}