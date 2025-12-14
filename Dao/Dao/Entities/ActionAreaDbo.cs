using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("action_area")]
public class ActionAreaDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("path_to_texture"), MaxLength(50)]
    public required string PathToTexture { get; set; }
}