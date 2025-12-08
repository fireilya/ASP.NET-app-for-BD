using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Enumerations;

namespace Dao.Entities;

[Table("affected_entity")]
public class AffectedEntityDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("affected_entity_type")]
    public required AffectedEntityType AffectedEntityType { get; set; }
}