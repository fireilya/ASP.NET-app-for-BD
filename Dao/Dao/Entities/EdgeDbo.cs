using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enumerations;

namespace Dao.Entities;

[Table("edge")]
public class EdgeDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("node1_id")]
    public required Guid Node1Id { get; set; }

    [Column("node2_id")]
    public required Guid Node2Id { get; set; }

    [Column("event_type")]
    public required EdgeType EventType { get; set; }
}