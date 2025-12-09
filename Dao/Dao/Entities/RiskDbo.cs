using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("risk")]
public class RiskDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("neutralizer_id")]
    public required Guid NeutralizerId { get; set; }

    [Column("location_id")]
    public required Guid LocationId { get; set; }
}