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
    };

    public WorkerDto ToDto(WorkerDbo dbo) => new()
    {
        Id = dbo.Id,
        Name = dbo.Name,
        EffectivenessCoeff = dbo.EffectivenessCoeff,
    };
}