using System;
using Domain.Enumerations;

namespace Domain.FlattenDtos;

public class PlayerSettingsDto
{
    public required Guid Id { get; set; }
    public required Guid PlayerId { get; set; }
    public required GameScreenMode EventType { get; set; }
    public required short MusicVolume { get; set; }
    public required short SfxVolume { get; set; }
    public required short TextSpeed { get; set; }
}