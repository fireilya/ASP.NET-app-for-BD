using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class EdgeConverter : IEntityConverter<EdgeDbo, EdgeDto>
{
    public EdgeDbo ToDbo(EdgeDto dto) => new()
    {
        Id = dto.Id,
        Node1Id = dto.Node1Id,
        Node2Id = dto.Node2Id,
        EventType = dto.EventType,
    };

    public EdgeDto ToDto(EdgeDbo dbo) => new()
    {
        Id = dbo.Id,
        Node1Id = dbo.Node1Id,
        Node2Id = dbo.Node2Id,
        EventType = dbo.EventType,
    };
}