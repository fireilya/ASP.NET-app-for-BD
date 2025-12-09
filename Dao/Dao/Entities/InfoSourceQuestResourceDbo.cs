using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("info_source_quest_resource")]
public class InfoSourceQuestResourceDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("info_source_id")]
    public required Guid InfoSourceId { get; set; }

    [Column("resource_id")]
    public required Guid ResourceId { get; set; }
}