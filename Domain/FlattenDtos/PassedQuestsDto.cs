using System;

namespace Domain.FlattenDtos;

public class PassedQuestsDto
{
    public required Guid Id { get; set; }
    public required Guid SaveId { get; set; }
    public required Guid QuestId { get; set; }
    public required short Score { get; set; }
}