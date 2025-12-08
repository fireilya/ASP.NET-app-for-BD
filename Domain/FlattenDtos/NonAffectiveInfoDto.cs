using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dao.Entities;

public class NonAffectiveInfoDto
{
    public required Guid BriefInfoId { get; set; }
    public required NonAffectiveInfoType NonAffectiveInfoType { get; set; }
}