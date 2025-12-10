using System;

namespace Domain.FlattenDtos;

public class SaveDto
{
    public required Guid Id { get; set; }
    public required DateTime Time { get; set; }
}