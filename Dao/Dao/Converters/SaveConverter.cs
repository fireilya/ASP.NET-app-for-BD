using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class SaveConverter : IEntityConverter<SaveDbo, SaveDto>
{
    public SaveDbo ToDbo(SaveDto dto) => new()
    {
        Id = dto.Id,
        Time = dto.Time,
    };

    public SaveDto ToDto(SaveDbo dbo) => new()
    {
        Id = dbo.Id,
        Time = dbo.Time,
    };
}