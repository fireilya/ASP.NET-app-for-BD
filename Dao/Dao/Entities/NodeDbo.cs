using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("node")]
public class NodeDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("district_id")]
    public required Guid DistrictId { get; set; }
}