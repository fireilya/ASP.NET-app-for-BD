using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public interface IGameEventConverter : IEntityConverter<GameEventDbo, GameEventDto>;

public class GameEventConverter : IGameEventConverter
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
        MaxOccuranceCount = dto.MaxOccuranceCount,
        EventData = dto.EventData,
    };

    public GameEventDto ToDto(GameEventDbo dbo) => new()
    {
        Id = dbo.Id,
        DistrictId = dbo.DistrictId,
        ResearchAreaId = dbo.ResearchAreaId,
        EventType = dbo.EventType,
        IsPositive = dbo.IsPositive,
        Name = dbo.Name,
        Description = dbo.Description,
        TimeDelayInMinutes = dbo.TimeDelayInMinutes,
        Chance = dbo.Chance,
        MaxOccuranceCount = dbo.MaxOccuranceCount,
        EventData = dbo.EventData,
    };
}