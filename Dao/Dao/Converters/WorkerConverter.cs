using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class WorkerConverter : IEntityConverter<WorkerDbo, WorkerDto>
{
    public WorkerDbo ToDbo(WorkerDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        EffectivenessCoeff = dto.EffectivenessCoeff,
        PathToIcon = dto.PathToIcon
    };

    public WorkerDto ToDto(WorkerDbo dbo) => new(dbo.Id, dbo.Name, dbo.PathToIcon, dbo.EffectivenessCoeff);
}