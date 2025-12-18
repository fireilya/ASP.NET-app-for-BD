using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class ActionAreaConverter : IEntityConverter<ActionAreaDbo, ActionAreaDto>
{
    public ActionAreaDbo ToDbo(ActionAreaDto dto) => new()
    {
        Id = dto.Id,
        PathToTexture = dto.PathToTexture,
        Name = dto.Name,
    };

    public ActionAreaDto ToDto(ActionAreaDbo dbo) => new(dbo.Id, dbo.PathToTexture,  dbo.Name);
}