using System;

namespace Domain.FlattenDtos;

public class StakeholderDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string PathToIcon { get; set; }
}