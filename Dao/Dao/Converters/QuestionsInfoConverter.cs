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
        QuestionType = dto.QuestionType,
    };

    public QuestionsInfoDto ToDto(QuestionsInfoDbo dbo) => new()
    {
        Id = dbo.Id,
        QuestionId = dbo.QuestionId,
        BriefInfoId = dbo.BriefInfoId,
        QuestionType = dbo.QuestionType,
    };
}