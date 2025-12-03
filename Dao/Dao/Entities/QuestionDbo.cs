using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enumerations;

namespace Dao.Entities;

[Table("questions")]
public class QuestionDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("quest_id"), Required]
    public required Guid QuestId { get; set; }

    [Column("parent_id")]
    public required Guid? ParentId { get; set; }

    [Column("content")]
    public required string Content { get; set; }

    [Column("answer")]
    public required string Answer { get; set; }

    [Column("question_type")]
    public required QuestionType Type { get; set; }
}