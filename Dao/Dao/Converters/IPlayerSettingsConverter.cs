using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public interface IPlayerSettingsConverter : IEntityConverter<PlayerSettingsDbo, PlayerSettingsDto>;

public class PlayerSettingsConverter : IPlayerSettingsConverter
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

    public PlayerSettingsDto ToDto(PlayerSettingsDbo dbo) => new()
    {
        Id = dbo.Id,
        PlayerId = dbo.PlayerId,
        EventType = dbo.EventType,
        MusicVolume = dbo.MusicVolume,
        SfxVolume = dbo.SfxVolume,
        TextSpeed = dbo.TextSpeed,
    };
}