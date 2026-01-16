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
        MappingKey = dto.MappingKey,
    };

    public LocationDto ToDto(LocationDbo dbo) => new(dbo.Id, dbo.ActionAreaId, dbo.Name, dbo.PathToIcon, dbo.MappingKey);
}