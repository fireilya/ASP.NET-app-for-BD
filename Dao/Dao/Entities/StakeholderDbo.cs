using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("stakeholder")]
public class StakeholderDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("name"), MaxLength(50)]
    public required string Name { get; set; }

    [Column("path_to_icon"), MaxLength(50)]
    public required string PathToIcon { get; set; }
}