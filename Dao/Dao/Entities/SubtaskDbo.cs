using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("subtask")]
public class SubtaskDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("affected_entity_id")]
    public required Guid AffectedEntityId { get; set; }

    [Column("name"), MaxLength(30)]
    public required string Name { get; set; }

    [Column("order")]
    public required short Order { get; set; }

    [Column("base_effectiveness")]
    public required int BaseEffectiveness { get; set; }

    [Column("is_use_capacity_tool")]
    public required bool IsUseCapacityTool { get; set; }
}
