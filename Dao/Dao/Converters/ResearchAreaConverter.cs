using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class ResearchAreaConverter : IEntityConverter<ResearchAreaDbo, ResearchAreaDto>
{
    public ResearchAreaDbo ToDbo(ResearchAreaDto dto) => new()
    {
        Id = dto.Id,
        PathToTexture = dto.PathToTexture,
    };

    public ResearchAreaDto ToDto(ResearchAreaDbo dbo) => new()
    {
        Id = dbo.Id,
        PathToTexture = dbo.PathToTexture,
    };
}