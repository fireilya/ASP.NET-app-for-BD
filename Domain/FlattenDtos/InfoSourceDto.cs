using System;

namespace Domain.FlattenDtos;

public class InfoSourceDto
{
    public required Guid Id { get; set; }
    public required Guid ResearchAreaId { get; set; }
    public required string Name { get; set; }
    public required string InfoText { get; set; }
    public required Guid InfoSourceLevelId { get; set; }
}