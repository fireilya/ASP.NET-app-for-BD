using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("quest_resource")]
public class QuestResourceDbo
{
    [Column("resource_id"), Key]
    public required Guid Id { get; set; }

    [Column("quest_id")]
    public required Guid QuestId { get; set; }

    [Column("name"), MaxLength(50)]
    public required string Name { get; set; }

    [Column("resource_type")]
    public required ResourceType Type { get; set; }
}