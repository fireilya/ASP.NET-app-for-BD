using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class GameEventConverter : IEntityConverter<GameEventDbo, GameEventDto>
{
    public GameEventDbo ToDbo(GameEventDto dto) => new()
    {
        Id = dto.Id,
        DistrictId = dto.DistrictId,
        ResearchAreaId = dto.ResearchAreaId,
        EventType = dto.EventType,
        IsPositive = dto.IsPositive,
        Name = dto.Name,
        Description = dto.Description,
        TimeDelayInMinutes = dto.TimeDelayInMinutes,
        Chance = dto.Chance,
        MaxOccurenceCount = dto.MaxOccurenceCount,
        EventData = dto.EventData,
    };

    public GameEventDto ToDto(GameEventDbo dbo) => new(
        dbo.Id, 
        dbo.DistrictId, 
        dbo.ResearchAreaId, 
        dbo.EventType,
        dbo.IsPositive,
        dbo.Name,
        dbo.Description,
        dbo.TimeDelayInMinutes,
        dbo.Chance,
        dbo.MaxOccurenceCount,
        dbo.EventData);
}