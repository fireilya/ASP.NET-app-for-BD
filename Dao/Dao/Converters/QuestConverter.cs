using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class QuestConverter : IEntityConverter<QuestDbo, QuestDto>
{
    public QuestDbo ToDbo(QuestDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        Parent = dto.Parent,
        StakeholderId = dto.StakeholderId,
        ResearchAreaId = dto.ResearchAreaId,
        ActionAreaId = dto.ActionAreaId,
        MaxQuestionsCount = dto.MaxQuestionsCount,
    };

    public QuestDto ToDto(QuestDbo dbo) => new()
    {
        Id = dbo.Id,
        Name = dbo.Name,
        Description = dbo.Description,
        Parent = dbo.Parent,
        StakeholderId = dbo.StakeholderId,
        ResearchAreaId = dbo.ResearchAreaId,
        ActionAreaId = dbo.ActionAreaId,
        MaxQuestionsCount = dbo.MaxQuestionsCount,
    };
}