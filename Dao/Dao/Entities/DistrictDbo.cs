using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("district")]
public class DistrictDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("research_area_id")]
    public required Guid ResearchAreaId { get; set; }

    [Column("name"), StringLength(50)]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }
}