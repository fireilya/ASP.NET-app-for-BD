using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class BriefInfoConverter : IEntityConverter<BriefInfoDbo, BriefInfoDto>
{
    public BriefInfoDbo ToDbo(BriefInfoDto dto) => new()
    {
        Id = dto.Id,
        QuestId = dto.QuestId,
        IsTrue = dto.IsTrue,
        AffectedEntityId = dto.AffectedEntityId,
        Content = dto.Content,
    };

    public BriefInfoDto ToDto(BriefInfoDbo dbo) => 
        new(dbo.Id, dbo.QuestId, dbo.IsTrue, dbo.AffectedEntityId, dbo.Content);
}
