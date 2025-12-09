using System;

namespace Domain.FlattenDtos;

public class QuestResourceDto
{
    public required Guid Id { get; set; }
    public required Guid QuestId { get; set; }
    public required string Name { get; set; }
    public required ResourceType Type { get; set; }
}