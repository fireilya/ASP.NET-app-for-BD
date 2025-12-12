using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("save")]
public class SaveDbo
{
    [Column("save_id"), Key]
    public required Guid Id { get; set; }

    [Column("time")]
    public required DateTime Time { get; set; }
}