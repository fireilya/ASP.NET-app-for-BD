using System;
using Domain.Enumerations;

namespace Domain.FlattenDtos;

public record GameEventDto
{
    public required Guid Id { get; set; }
    public required Guid? DistrictId { get; set; }
    public required Guid ResearchAreaId { get; set; }
    public required GameEventType EventType { get; set; }
    public required bool IsPositive { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required short TimeDelayInMinutes { get; set; }
    public required float Chance { get; set; }
    public required short MaxOccuranceCount { get; set; }
    public required string EventData { get; set; }
}