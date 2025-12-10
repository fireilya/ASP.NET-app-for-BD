using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestSourceInfoConverter : IEntityConverter<QuestSourceInfoDbo, QuestSourceInfoDto>
{
    public QuestSourceInfoDbo ToDbo(QuestSourceInfoDto dto) => new()
    {
        Id = dto.Id,
        QuestId = dto.QuestId,
        ResearchAreaId = dto.ResearchAreaId,
        InfoSourceId = dto.InfoSourceId,
    };

    public QuestSourceInfoDto ToDto(QuestSourceInfoDbo dbo) => new()
    {
        Id = dbo.Id,
        QuestId = dbo.QuestId,
        ResearchAreaId = dbo.ResearchAreaId,
        InfoSourceId = dbo.InfoSourceId,
    };
}