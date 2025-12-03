using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("research_area")]
public class ResearchAreaDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("path_to_texture"), StringLength(50)]
    public required string PathToTexture { get; set; }
}