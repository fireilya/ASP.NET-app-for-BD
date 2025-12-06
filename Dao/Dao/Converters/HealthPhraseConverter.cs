using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Converters;

public class HealthPhraseConverter : IEntityConverter<HealthPhraseDbo, HealthPhraseDto>
{
    public HealthPhraseDbo ToDbo(HealthPhraseDto dto) => new()
    {
        Id = dto.Id,
        Text = dto.Text,
        ShowCount = dto.ShowCount,
    };

    public HealthPhraseDto ToDto(HealthPhraseDbo dbo) => new()
    {
        Id = dbo.Id,
        Text = dbo.Text,
        ShowCount = dbo.ShowCount,
    };
}