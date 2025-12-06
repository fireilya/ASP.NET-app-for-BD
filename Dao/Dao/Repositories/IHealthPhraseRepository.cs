using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface IHealthPhraseRepository : IRepository
{
    Task<HealthPhraseDto[]> SelectAllAsync();
    Task IncrementAsync(Guid id);
}

public class HealthPhraseRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<HealthPhraseDbo, HealthPhraseDto> converter
) : RepositoryBase<HealthPhraseDbo, HealthPhraseDto, Guid>(dataContext, converter, x => x.Id), IHealthPhraseRepository
{
    public async Task<HealthPhraseDto[]> SelectAllAsync()
    {
        var allHealthPhrases =
            await DataContext.ExecuteQueryAsync<HealthPhraseDbo, HealthPhraseDbo[]>(query => query.ToArrayAsync());

        return Converter.ToDto(allHealthPhrases);
    }

    public Task IncrementAsync(Guid id) => DataContext.UpdatePropertiesAsync<HealthPhraseDbo, Guid>(
        x => x.SetProperty(phrase => phrase.ShowCount, phrase => phrase.ShowCount + 1),
        phrase => phrase.Id,
        id
    );
}