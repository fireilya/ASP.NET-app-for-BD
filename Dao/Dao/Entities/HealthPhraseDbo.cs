using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("health_phrases")]
public class HealthPhraseDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("text"), Required]
    public required string Text { get; set; }

    [Column("show_count"), Required]
    public required int ShowCount { get; set; }
}