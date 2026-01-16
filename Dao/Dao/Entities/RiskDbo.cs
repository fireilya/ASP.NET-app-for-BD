using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("risk")]
public class RiskDbo
{
    [Column("resource_id"), Key]
    public required Guid Id { get; set; }

    [Column("neutralizer_id")]
    public required Guid NeutralizerId { get; set; }

    [Column("location_id")]
    public required Guid LocationId { get; set; }
    
    [Column("name")]
    public required string Name { get; set; }
    
    [Column("path_to_icon")]
    public required string PathToIcon { get; set; }

    [Column("description")]
    public required string Description { get; set; }
    
    [Column("happened_message")]
    public required string HappenedMessage { get; set; }
    
    [Column("bad_influence_message")]
    public required string BadInfluenceMessage { get; set; }
}