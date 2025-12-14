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
    };

    public ActionAreaDto ToDto(ActionAreaDbo dbo) => new()
    {
        Id = dbo.Id,
        PathToTexture = dbo.PathToTexture,
    };
}