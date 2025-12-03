using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestionConverter : IEntityConverter<QuestionDbo, QuestionDto>
{
    public QuestionDbo ToDbo(QuestionDto dto) => new()
    {
        Id = dto.Id,
        QuestId = dto.QuestId,
        ParentId = dto.ParentId,
        Content = dto.Content,
        Answer = dto.Answer,
        Type = dto.Type,
    };

    public QuestionDto ToDto(QuestionDbo dbo) => new()
    {
        Id = dbo.Id,
        QuestId = dbo.QuestId,
        ParentId = dbo.ParentId,
        Content = dbo.Content,
        Answer = dbo.Answer,
        Type = dbo.Type,
    };
}