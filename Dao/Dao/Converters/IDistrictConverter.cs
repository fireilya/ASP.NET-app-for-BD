using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public interface IDistrictConverter : IEntityConverter<DistrictDbo, DistrictDto>;

public class DistrictConverter : IDistrictConverter
{
    public DistrictDbo ToDbo(DistrictDto dto) => new()
    {
        Id = dto.Id,
        ResearchAreaId = dto.ResearchAreaId,
        Name = dto.Name,
        Description = dto.Description,
    };

    public DistrictDto ToDto(DistrictDbo dbo) => new()
    {
        Id = dbo.Id,
        ResearchAreaId = dbo.ResearchAreaId,
        Name = dbo.Name,
        Description = dbo.Description,
    };
}