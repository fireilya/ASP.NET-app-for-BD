using System;

namespace Domain.FlattenDtos;

public class QuestSourceInfoDto
{
    public required Guid Id { get; set; }
    public required Guid QuestId { get; set; }
    public required Guid ResearchAreaId { get; set; }
    public required Guid InfoSourceId { get; set; }
}