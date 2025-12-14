using System;

namespace Domain.FlattenDtos;

public class QuestDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Parent { get; set; }
    public required Guid StakeholderId { get; set; }
    public required Guid ResearchAreaId { get; set; }
    public required Guid ActionAreaId { get; set; }
    public required short MaxQuestionsCount { get; set; }
}