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
        Name = dto.Name,
        PathToIcon = dto.PathToIcon,
        Description = dto.Description,
        HappenedMessage = dto.HappenedMessage,
        BadInfluenceMessage = dto.BadInfluenceMessage,
    };

    public RiskDto ToDto(RiskDbo dbo) => new(
        dbo.Id,
        dbo.Name,
        dbo.PathToIcon,
        dbo.Description,
        dbo.HappenedMessage,
        dbo.BadInfluenceMessage,
        dbo.NeutralizerId,
        dbo.LocationId
    );
}