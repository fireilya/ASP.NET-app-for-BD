using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class InfoSourceQuestResourceConverter : IEntityConverter<InfoSourceQuestResourceDbo, InfoSourceQuestResourceDto>
{
    public InfoSourceQuestResourceDbo ToDbo(InfoSourceQuestResourceDto dto) => new()
    {
        Id = dto.Id,
        InfoSourceId = dto.InfoSourceId,
        ResourceId = dto.ResourceId,
    };

    public InfoSourceQuestResourceDto ToDto(InfoSourceQuestResourceDbo dbo) => new()
    {
        Id = dbo.Id,
        InfoSourceId = dbo.InfoSourceId,
        ResourceId = dbo.ResourceId,
    };
}