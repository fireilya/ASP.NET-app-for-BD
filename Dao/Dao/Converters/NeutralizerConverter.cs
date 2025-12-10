using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class NeutralizerConverter : IEntityConverter<NeutralizerDbo, NeutralizerDto>
{
    public NeutralizerDbo ToDbo(NeutralizerDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        PathToIcon = dto.PathToIcon,
    };

    public NeutralizerDto ToDto(NeutralizerDbo dbo) => new()
    {
        Id = dbo.Id,
        Name = dbo.Name,
        PathToIcon = dbo.PathToIcon,
    };
}