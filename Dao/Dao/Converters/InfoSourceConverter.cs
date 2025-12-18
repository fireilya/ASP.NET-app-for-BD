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

    public InfoSourceDto ToDto(InfoSourceDbo dbo) => new(
        dbo.Id,
        dbo.ResearchAreaId,
        dbo.Name,
        dbo.InfoText,
        dbo.InfoSourceLevelId
    );
}