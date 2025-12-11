using System;

namespace Domain.FlattenDtos;

public class QuestionsInfoDto
{
    public required Guid Id { get; set; }
    public required Guid QuestionId { get; set; }
    public required Guid BriefInfoId { get; set; }
    public required Guid QuestionType { get; set; }
}