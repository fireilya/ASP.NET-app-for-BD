using System;

namespace Domain.FlattenDtos;

public record ObstacleDto
{
    public required Guid Id { get; set; }
    public required Guid ResearchAreaId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required short TimeDelayInMinutes { get; set; }
    public required short MaxInstance { get; set; }
    public required string PathToIcon { get; set; }
}