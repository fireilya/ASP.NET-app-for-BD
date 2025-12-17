using System;

namespace Domain.FlattenDtos;

public class TaskDto
{
    public required Guid Id { get; set; }
    public required Guid AffectedEntityId { get; set; }
    public required Guid LocationId { get; set; }
    public required string Name { get; set; }
    public required int Target { get; set; }
    public required short DayLimit { get; set; }
}