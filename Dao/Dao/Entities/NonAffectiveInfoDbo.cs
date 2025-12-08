using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dao.Entities;

[Table("non_affective_info")]
public class NonAffectiveInfoDbo
{
    [Column("brief_info_id"), Key]
    public required Guid BriefInfoId { get; set; }

    [Column("non_affective_info_type"), Key]
    public required NonAffectiveInfoType NonAffectiveInfoType { get; set; }
}