using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("task")]
public class TaskDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("affected_entity_id")]
    public required Guid AffectedEntityId { get; set; }

    [Column("location_id")]
    public required Guid LocationId { get; set; }

    [Column("name"), MaxLength(30)]
    public required string Name { get; set; }

    [Column("target")]
    public required int Target { get; set; }

    [Column("day_limit")]
    public required short DayLimit { get; set; }
}