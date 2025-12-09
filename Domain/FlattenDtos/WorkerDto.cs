using System;

namespace Domain.FlattenDtos;

public class WorkerDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required double EffectivenessCoeff { get; set; }
}