using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestWorkerConverter : IEntityConverter<QuestWorkerDbo, QuestWorkerDto>
{
    public QuestWorkerDbo ToDbo(QuestWorkerDto dto) => new()
    {
        Id = dto.Id,
        WorkerId = dto.WorkerId,
        QuestId = dto.QuestId,
    };

    public QuestWorkerDto ToDto(QuestWorkerDbo dbo) => new(dbo.Id, dbo.WorkerId, dbo.QuestId);
}