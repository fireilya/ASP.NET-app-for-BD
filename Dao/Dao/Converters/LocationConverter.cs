using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class LocationConverter : IEntityConverter<LocationDbo, LocationDto>
{
    public LocationDbo ToDbo(LocationDto dto) => new()
    {
        Id = dto.Id,
        ActionAreaId = dto.ActionAreaId,
        Name = dto.Name,
        PathToIcon = dto.PathToIcon,
    };

    public LocationDto ToDto(LocationDbo dbo) => new()
    {
        Id = dbo.Id,
        ActionAreaId = dbo.ActionAreaId,
        Name = dbo.Name,
        PathToIcon = dbo.PathToIcon,
    };
}