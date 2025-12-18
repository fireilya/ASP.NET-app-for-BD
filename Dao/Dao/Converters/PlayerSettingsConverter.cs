using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class PlayerSettingsConverter : IEntityConverter<PlayerSettingsDbo, PlayerSettingsDto>
{
    public PlayerSettingsDbo ToDbo(PlayerSettingsDto dto) => new()
    {
        Id = dto.Id,
        PlayerId = dto.PlayerId,
        EventType = dto.EventType,
        MusicVolume = dto.MusicVolume,
        SfxVolume = dto.SfxVolume,
        TextSpeed = dto.TextSpeed,
    };

    public PlayerSettingsDto ToDto(PlayerSettingsDbo dbo) => new(
        dbo.Id,
        dbo.PlayerId,
        dbo.EventType,
        dbo.MusicVolume,
        dbo.SfxVolume,
        dbo.TextSpeed
    );
}