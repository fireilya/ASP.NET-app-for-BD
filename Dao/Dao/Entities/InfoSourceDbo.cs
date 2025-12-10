using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("info_source")]
public class InfoSourceDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("research_area_id")]
    public required Guid ResearchAreaId { get; set; }

    [Column("name"), MaxLength(50)]
    public required string Name { get; set; }

    [Column("info_text")]
    public required string InfoText { get; set; }

    [Column("info_source_level_id")]
    public required Guid InfoSourceLevelId { get; set; }
}