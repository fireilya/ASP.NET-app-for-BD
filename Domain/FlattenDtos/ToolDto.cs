using System;

namespace Domain.FlattenDtos;

public class ToolDto
{
    public required Guid Id { get; set; }
    public required Guid ResourceId { get; set; }
    public required string PathToIcon { get; set; }
}