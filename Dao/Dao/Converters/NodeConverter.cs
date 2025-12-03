using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class NodeConverter : IEntityConverter<NodeDbo, NodeDto>
{
    public NodeDbo ToDbo(NodeDto dto) => new()
    {
        Id = dto.Id,
        DistrictId = dto.DistrictId,
    };

    public NodeDto ToDto(NodeDbo dbo) => new()
    {
        Id = dbo.Id,
        DistrictId = dbo.DistrictId,
    };
}