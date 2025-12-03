using System;

namespace Domain.FlattenDtos;

public record NodeDto
{
    public required Guid Id { get; set; }
    public required Guid DistrictId { get; set; }
}