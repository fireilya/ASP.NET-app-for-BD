using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("quest_source_info")]
public class QuestSourceInfoDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("quest_id")]
    public required Guid QuestId { get; set; }

    [Column("research_area_id")]
    public required Guid ResearchAreaId { get; set; }

    [Column("info_source_id")]
    public required Guid InfoSourceId { get; set; }
}