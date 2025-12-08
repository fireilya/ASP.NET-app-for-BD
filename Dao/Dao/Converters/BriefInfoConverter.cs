using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters

public class BriefInfoConverter : IEntityConverter<BriefInfoDbo, BriefInfoConverterDto>
{
    public BriefInfoDbo ToDbo(BriefInfoDto dto) => new()
    {
        Id = dto.Id,
        QuestId = dto.QuestId,
        IsTrue = dto.IsTrue,
        AffectedEntityId = dto.AffectedEntityId,
        Content = dto.Content,
    };

    public BriefInfoDto ToDto(BriefInfoDbo dbo) => new()
    {
        Id = dbo.Id,
        QuestId = dbo.QuestId,
        IsTrue = dbo.IsTrue,
        AffectedEntityId = dbo.AffectedEntityId,
        Content = dbo.Content,
    };
}
