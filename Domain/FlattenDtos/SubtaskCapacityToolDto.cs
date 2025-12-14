using System;

namespace Domain.FlattenDtos;

public class SubtaskCapacityToolDto
{
    public required Guid Id { get; set; }
    public required Guid ResourceId { get; set; }
    public required Guid SubtaskId { get; set; }
    public required short Capacity { get; set; }
}