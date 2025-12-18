using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class RiskConverter : IEntityConverter<RiskDbo, RiskDto>
{
    public RiskDbo ToDbo(RiskDto dto) => new()
    {
        Id = dto.Id,
        NeutralizerId = dto.NeutralizerId,
        LocationId = dto.LocationId,
        Description = dto.Description,
        PathToIcon = dto.PathToIcon,
    };

    public RiskDto ToDto(RiskDbo dbo) => new(
        dbo.Id,
        dbo.PathToIcon,
        dbo.Description,
        dbo.NeutralizerId,
        dbo.LocationId
    );
}