using System;

namespace Domain.FlattenDtos;

public class InfoSourceLevelDto
{
    public required Guid Id { get; set; }
    public required Guid Level { get; set; }
    public required short InteractTimeInMinute { get; set; }
}