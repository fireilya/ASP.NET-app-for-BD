using System;

namespace Domain.FlattenDtos;

public class HealthPhraseDto
{
    public required Guid Id { get; set; }
    public required string Text { get; set; }
    public required int ShowCount { get; set; }
}