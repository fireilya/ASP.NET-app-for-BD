using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class IconConverter : IEntityConverter<IconDbo, IconDto>
{
    public IconDbo ToDbo(IconDto dto) => new IconDbo
    {
        Id = dto.Id,
        Body = dto.Body,
    };

    public IconDto ToDto(IconDbo dbo) => new(dbo.Id, dbo.Body);
}