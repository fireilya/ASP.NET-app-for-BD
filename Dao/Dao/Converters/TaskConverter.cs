using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class TaskConverter : IEntityConverter<TaskDbo, TaskDto>
{
    public TaskDbo ToDbo(TaskDto dto) => new()
    {
        Id = dto.Id,
        LocationId = dto.LocationId,
        Name = dto.Name,
        Target = dto.Target,
        DayLimit = dto.DayLimit,
        IsTrue = dto.IsTrue,
    };

    public TaskDto ToDto(TaskDbo dbo) => new(
        dbo.Id,
        dbo.LocationId,
        dbo.Name,
        dbo.Target,
        dbo.DayLimit,
        dbo.IsTrue
    );
}