using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IInfoSourceQuestResourceRepository : IRepository
{
    Task CreateAsync(InfoSourceQuestResourceDto dto);
    Task<InfoSourceQuestResourceDto?> FindAsync(Guid id);
    Task UpdateAsync(InfoSourceQuestResourceDto dto);
    Task DeleteAsync(InfoSourceQuestResourceDto dto);
}

public class InfoSourceQuestResourceRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<InfoSourceQuestResourceDbo, InfoSourceQuestResourceDto> converter
) : RepositoryBase<InfoSourceQuestResourceDbo, InfoSourceQuestResourceDto, Guid>(dataContext, converter, x => x.Id), IInfoSourceQuestResourceRepository;