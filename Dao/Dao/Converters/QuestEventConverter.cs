using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestEventConverter : IEntityConverter<QuestEventDbo, QuestEventDto>
{
    public QuestEventDbo ToDbo(QuestEventDto dto) => new()
    {
        Id = dto.Id,
        EventId = dto.EventId,
        ResearchAreaId = dto.ResearchAreaId,
    };

    public QuestEventDto ToDto(QuestEventDbo dbo) => new()
    {
        Id = dbo.Id,
        EventId = dbo.EventId,
        ResearchAreaId = dbo.ResearchAreaId,
    };
}