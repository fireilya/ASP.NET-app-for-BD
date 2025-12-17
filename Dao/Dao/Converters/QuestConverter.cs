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

    public QuestDto ToDto(QuestDbo dbo) => new(
        dbo.Id, 
        dbo.Name, 
        dbo.Description, 
        dbo.Parent, 
        dbo.StakeholderId, 
        dbo.ResearchAreaId, 
        dbo.ActionAreaId, 
        dbo.MaxQuestionsCount);
}