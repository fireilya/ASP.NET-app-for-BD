using System;

namespace Domain.FlattenDtos;

public class SubtaskToolDto
{
    public required Guid Id { get; set; }
    public required Guid ResourceId { get; set; }
    public required Guid SubtaskId { get; set; }
}