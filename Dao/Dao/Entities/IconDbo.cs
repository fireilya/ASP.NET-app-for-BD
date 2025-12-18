using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("icon")]
public class IconDbo
{
    [Column("id"), Key]
    public required string Id { get; set; }

    [Column("body"), Required]
    public required byte[] Body { get; set; }
}