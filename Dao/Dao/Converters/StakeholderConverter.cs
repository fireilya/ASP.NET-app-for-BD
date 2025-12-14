using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class StakeholderConverter : IEntityConverter<StakeholderDbo, StakeholderDto>
{
    public StakeholderDbo ToDbo(StakeholderDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        PathToIcon = dto.PathToIcon,
    };

    public StakeholderDto ToDto(StakeholderDbo dbo) => new()
    {
        Id = dbo.Id,
        Name = dbo.Name,
        PathToIcon = dbo.PathToIcon,
    };
}