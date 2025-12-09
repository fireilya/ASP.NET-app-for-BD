using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestResourceConverter : IEntityConverter<QuestResourceDbo, QuestResourceDto>
{
    public QuestResourceDbo ToDbo(QuestResourceDto dto) => new()
    {
        Id = dto.Id,
        QuestId = dto.QuestId,
        Name = dto.Name,
    };

    public QuestResourceDto ToDto(QuestResourceDbo dbo) => new()
    {
        Id = dbo.Id,
        QuestId = dbo.QuestId,
        Name = dbo.Name,
    };
}