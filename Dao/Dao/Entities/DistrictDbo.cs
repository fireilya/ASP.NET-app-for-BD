using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.EFCore;

namespace Dao.Entities;

[Table("district")]
public class DistrictDbo
{
    [Column("id", TypeName = PostgresDataType.Guid), Key]
    public required Guid Id { get; set; }

    [Column("research_area_id", TypeName = PostgresDataType.Guid)]
    public required Guid ResearchAreaId { get; set; }

    [Column("name", TypeName = PostgresDataType.Text)]
    public required string Name { get; set; }

    [Column("description", TypeName = PostgresDataType.Text)]
    public required string Description { get; set; }
}