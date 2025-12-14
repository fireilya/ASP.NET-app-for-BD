using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("location")]
public class LocationDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("action_area_id")]
    public required Guid ActionAreaId { get; set; }

    [Column("name"), MaxLength(50)]
    public required string Name { get; set; }

    [Column("path_to_icon"), MaxLength(50)]
    public required string PathToIcon { get; set; }
}