using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class InfoSourceLevelConverter : IEntityConverter<InfoSourceLevelDbo, InfoSourceLevelDto>
{
    public InfoSourceLevelDbo ToDbo(InfoSourceLevelDto dto) => new()
    {
        Id = dto.Id,
        InteractTimeInMinute = dto.InteractTimeInMinute,
    };

    public InfoSourceLevelDto ToDto(InfoSourceLevelDbo dbo) => new()
    {
        Id = dbo.Id,
        InteractTimeInMinute = dbo.InteractTimeInMinute,
    };
}