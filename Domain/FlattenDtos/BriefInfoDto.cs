using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.FlattenDtos;

public class BriefInfoDto
{
    public required Guid Id { get; set; }
    public required Guid QuestId { get; set; }
    public required bool IsTrue { get; set; }
    public required Guid AffectedEntityId { get; set; }
    public required string Content { get; set; }
}