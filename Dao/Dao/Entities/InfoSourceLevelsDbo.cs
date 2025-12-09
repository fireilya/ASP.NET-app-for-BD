using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("info_source_levels")]
public class InfoSourceLevelDbo
{
    [Column("id"), Key]
    public required int Id { get; set; }

    [Column("interact_time_in_minute")]
    public required short InteractTimeInMinute { get; set; }
}