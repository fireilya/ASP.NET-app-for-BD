using System;

namespace Domain.FlattenDtos;

public record ResearchAreaDto
{
    public required Guid Id { get; set; }
    public required string PathToTexture { get; set; }
}