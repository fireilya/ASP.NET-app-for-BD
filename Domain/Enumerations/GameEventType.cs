namespace Domain.Enumerations;

[StorageEnumeration("game_event_type")]
public enum GameEventType
{
    MoveAcceleration = 1,
    EdgeBreak = 2,
    Neutralize = 3,
    Simple = 4,
    InteractionAcceleration = 5,
    Teleportation = 6,
}