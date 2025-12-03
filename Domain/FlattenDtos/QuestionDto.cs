using System;
using Domain.Enumerations;

namespace Domain.FlattenDtos;

public class QuestionDto
{
    public required Guid Id { get; set; }
    public required Guid QuestId { get; set; }
    public required Guid? ParentId { get; set; }
    public required string Content { get; set; }
    public required string Answer { get; set; }
    public required QuestionType Type { get; set; }
}