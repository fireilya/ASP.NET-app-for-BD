using System;

namespace Domain.FlattenDtos;

public class SubtaskDto
{
    public required Guid Id { get; set; }
    public required Guid AffectedEntityId { get; set; }
    public required string Name { get; set; }
    public required short Order { get; set; }
    public required int BaseEffectiveness { get; set; }
    public required bool IsUseCapacityTool { get; set; }
}