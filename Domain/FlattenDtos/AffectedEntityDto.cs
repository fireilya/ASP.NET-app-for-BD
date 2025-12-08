using System;
using Domain.Enumerations;

namespace Domain.FlattenDtos;
public class AffectedEntityDto

{
    public required Guid Id { get; set; }
    public required AffectedEntityType AffectedEntityType { get; set; }
}
