using System;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class NonAffectiveInfoConverter : IEntityConverter<NonAffectiveInfoDbo, NonAffectiveInfoDto>
{
    public NonAffectiveInfoDbo ToDbo(NonAffectiveInfoDto dto) => new()
    {
        BriefInfoId = dto.BriefInfoId,
        NonAffectiveInfoType = dto.NonAffectiveInfoType,
    };
    public NonAffectiveInfoDto ToDto(NonAffectiveInfoDbo dbo) => new()
    {
        BriefInfoId = dbo.BriefInfoId,
        NonAffectiveInfoType = dbo.NonAffectiveInfoType,
    };
}