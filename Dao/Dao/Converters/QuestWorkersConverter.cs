using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestWorkersConverter : IEntityConverter<QuestWorkersDbo, QuestWorkersDto>
{
    public QuestWorkersDbo ToDbo(QuestWorkersDto dto) => new()
    {
        Id = dto.Id,
        WorkerId = dto.WorkerId,
        QuestId = dto.QuestId,
    };

    public QuestWorkersDto ToDto(QuestWorkersDbo dbo) => new()
    {
        Id = dbo.Id,
        WorkerId = dbo.WorkerId,
        QuestId = dbo.QuestId,
    };
}