using System;
namespace Domain.FlattenDtos;
public class AffectedEntityDto
{
    public required Guid Id { get; set; }
    public required Guid QuestId { get; set; }
    public required AffectedEntityType AffectedEntityType { get; set; }
}
