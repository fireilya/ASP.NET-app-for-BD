using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.EFCore;
using Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Dao.Entities;

[Table("player_settings")]
[Index(nameof(PlayerId), IsUnique = true)]
public class PlayerSettingsDbo
{
    [Column("id", TypeName = PostgresDataType.Guid), Key]
    public required Guid Id { get; set; }

    [Column("player_id", TypeName = PostgresDataType.Guid)]
    public required Guid PlayerId { get; set; }

    [Column("screen_mode", TypeName = EnumNames.GameScreenMode)]
    public required GameScreenMode EventType { get; set; }

    [Column("music_volume", TypeName = PostgresDataType.Short), Range(0, 100)]
    public required short MusicVolume { get; set; }

    [Column("sfx_volume", TypeName = PostgresDataType.Short), Range(0, 100)]
    public required short SfxVolume { get; set; }

    [Column("text_speed", TypeName = PostgresDataType.Short), Range(0, 100)]
    public required short TextSpeed { get; set; }
}