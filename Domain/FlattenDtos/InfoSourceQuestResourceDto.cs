using System;

namespace Domain.FlattenDtos;

public class InfoSourceQuestResourceDto
{
    public Guid Id { get; set; }
    public Guid InfoSourceId { get; set; }
    public Guid ResourceId { get; set; }
}