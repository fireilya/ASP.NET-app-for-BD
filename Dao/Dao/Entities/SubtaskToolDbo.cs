using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("subtask_tool")]
public class SubtaskToolDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("resource_id")]
    public required Guid ResourceId { get; set; }

    [Column("subtask_id")]
    public required Guid SubtaskId { get; set; }
}