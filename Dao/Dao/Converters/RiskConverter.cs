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
    };

    public RiskDto ToDto(RiskDbo dbo) => new()
    {
        Id = dbo.Id,
        NeutralizerId = dbo.NeutralizerId,
        LocationId = dbo.LocationId,
    };
}