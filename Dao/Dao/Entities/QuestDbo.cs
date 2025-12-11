using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("quest")]
public class QuestDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("name"), MaxLength(50)]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("parent")]
    public required int Parent { get; set; }

    [Column("stakeholder_id")]
    public required Guid StakeholderId { get; set; }

    [Column("research_area_id")]
    public required Guid ResearchAreaId { get; set; }

    [Column("action_area_id")]
    public required Guid ActionAreaId { get; set; }

    [Column("max_questions_count")]
    public required short MaxQuestionsCount { get; set; }
}