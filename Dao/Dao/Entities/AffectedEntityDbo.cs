using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dao.Entities;

[Table("affected_entity")]
public class AffectedEntityDbo
{
    [Column("affected_entity_id"), Key]
    public required Guid Id { get; set; }

    [Column("quest_id")]
    public required Guid QuestId { get; set; }

    [Column("affected_entity_type")]
    public required AffectedEntityType AffectedEntityType { get; set; }
}