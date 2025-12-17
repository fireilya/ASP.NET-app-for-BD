using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestionsInfoConverter : IEntityConverter<QuestionsInfoDbo, QuestionsInfoDto>
{
    public QuestionsInfoDbo ToDbo(QuestionsInfoDto dto) => new()
    {
        Id = dto.Id,
        QuestionId = dto.QuestionId,
        BriefInfoId = dto.BriefInfoId,
        Type = dto.Type,
    };

    public QuestionsInfoDto ToDto(QuestionsInfoDbo dbo) => new(dbo.Id, dbo.QuestionId, dbo.BriefInfoId, dbo.Type);
}