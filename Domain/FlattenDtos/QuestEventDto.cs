using System;

namespace Domain.FlattenDtos;

public record QuestEventDto
{
    public required Guid Id { get; set; }
    public required Guid EventId { get; set; }
    public required Guid ResearchAreaId { get; set; }
}