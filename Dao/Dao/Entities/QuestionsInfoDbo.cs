using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("questions_info")]
public class QuestionsInfoDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("question_id")]
    public required Guid QuestionId { get; set; }

    [Column("brief_info_id")]
    public required Guid BriefInfoId { get; set; }

    [Column("question_type")]
    public required Guid QuestionType { get; set; }
}