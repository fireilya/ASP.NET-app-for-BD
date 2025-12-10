using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("quest_workers")]
public class QuestWorkerDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("worker_id")]
    public required Guid WorkerId { get; set; }

    [Column("quest_id")]
    public required Guid QuestId { get; set; }
}