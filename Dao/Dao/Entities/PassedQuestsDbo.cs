using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("passed_quests")]
public class PassedQuestsDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("save_id")]
    public required Guid SaveId { get; set; }

    [Column("quest_id")]
    public required Guid QuestId { get; set; }

    [Column("score")]
    public required short Score { get; set; }
}