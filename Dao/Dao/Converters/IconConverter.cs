using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class IconConverter : IEntityConverter<IconDbo, IconDto>
{
    public IconDbo ToDbo(IconDto dto) => new IconDbo
    {
        Path = dto.Path,
        Body = dto.Body,
    };

    public IconDto ToDto(IconDbo dbo) => new(dbo.Path, dbo.Body);
}