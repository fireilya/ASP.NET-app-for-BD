using System;

namespace Domain.FlattenDtos;

public class ActionAreaDto
{
    public required Guid Id { get; set; }
    public required string PathToTexture { get; set; }
}