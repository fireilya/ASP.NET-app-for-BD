using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("node")]
public class QuestEventDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("event_id")]
    public required Guid EventId { get; set; }

    [Column("research_area_id")]
    public required Guid ResearchAreaId { get; set; }
}