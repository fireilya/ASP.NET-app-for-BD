using System;

namespace Domain.FlattenDtos;

public class RiskDto
{
    public required Guid Id { get; set; }
    public required Guid NeutralizerId { get; set; }
    public required Guid LocationId { get; set; }
}