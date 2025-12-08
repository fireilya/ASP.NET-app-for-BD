using System;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class AffectedEntityConverter : IEntityConverter<AffectedEntityDbo, AffectedEntityDto>
{
    public AffectedEntityDbo ToDbo(AffectedEntityDto dto) => new()
    {
        Id = dto.Id,
        QuestId = dto.QuestId,
        AffectedEntityType = dto.AffectedEntityType,
    };
    public AffectedEntityDto ToDto(AffectedEntityDbo dbo) => new()
    {
        Id = dbo.Id,
        QuestId = dbo.QuestId,
        AffectedEntityType = dbo.AffectedEntityType,
    };
}