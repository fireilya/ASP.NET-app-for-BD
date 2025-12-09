using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class InfoSourceConverter : IEntityConverter<InfoSourceDbo, InfoSourceDto>
{
    public InfoSourceDbo ToDbo(InfoSourceDto dto) => new()
    {
        Id = dto.Id,
        ResearchAreaId = dto.ResearchAreaId,
        Name = dto.Name,
        InfoText = dto.InfoText,
        InfoSourceLevelId = dto.InfoSourceLevelId,
    };

    public InfoSourceDto ToDto(InfoSourceDbo dbo) => new()
    {
        Id = dbo.Id,
        ResearchAreaId = dbo.ResearchAreaId,
        Name = dbo.Name,
        InfoText = dbo.InfoText,
        InfoSourceLevelId = dbo.InfoSourceLevelId,
    };
}