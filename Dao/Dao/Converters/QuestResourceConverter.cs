using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Domain.Enumerations;

namespace Dao.Converters;

public class QuestResourceConverter : IEntityConverter<QuestResourceDbo, QuestResourceDto>
{
    public QuestResourceDbo ToDbo(QuestResourceDto dto) => new()
    {
        Id = dto.Id,
        QuestId = dto.QuestId,
        Name = dto.Name,
        Type = dto.Type,
    };

    public QuestResourceDto ToDto(QuestResourceDbo dbo) => new()
    {
        Id = dbo.Id,
        QuestId = dbo.QuestId,
        Name = dbo.Name,
        Type = dbo.Type,
    };
}