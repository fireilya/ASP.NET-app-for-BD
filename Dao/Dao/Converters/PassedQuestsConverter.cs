using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class PassedQuestsConverter : IEntityConverter<PassedQuestsDbo, PassedQuestsDto>
{
    public PassedQuestsDbo ToDbo(PassedQuestsDto dto) => new()
    {
        Id = dto.Id,
        SaveId = dto.SaveId,
        QuestId = dto.QuestId,
        Score = dto.Score,
    };

    public PassedQuestsDto ToDto(PassedQuestsDbo dbo) => new()
    {
        Id = dbo.Id,
        SaveId = dbo.SaveId,
        QuestId = dbo.QuestId,
        Score = dbo.Score,
    };
}