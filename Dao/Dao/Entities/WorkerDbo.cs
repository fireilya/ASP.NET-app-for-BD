using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("worker")]
public class WorkerDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }
        
    [Column("effectiveness_coeff")]
    public required double EffectivenessCoeff { get; set; }
}