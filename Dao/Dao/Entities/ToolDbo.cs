using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("tool")]
public class ToolDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("resource_id")]
    public required Guid ResourceId { get; set; }

    [Column("path_to_icon"), MaxLength(50)]
    public required string PathToIcon { get; set; }
}