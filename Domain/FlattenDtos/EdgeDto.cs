using System;
using Domain.Enumerations;

namespace Domain.FlattenDtos;

public record EdgeDto
{
    public required Guid Id { get; set; }
    public required Guid Node1Id { get; set; }
    public required Guid Node2Id { get; set; }
    public required EdgeType EventType { get; set; }
}