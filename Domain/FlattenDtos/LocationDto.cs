using System;

namespace Domain.FlattenDtos;

public class LocationDto
{
    public required Guid Id { get; set; }
    public required Guid ActionAreaId { get; set; }
    public required string Name { get; set; }
    public required string PathToIcon { get; set; }
}