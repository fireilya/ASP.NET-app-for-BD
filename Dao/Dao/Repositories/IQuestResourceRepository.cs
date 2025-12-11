using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Domain.Enumerations;

namespace Dao.Repositories;

public interface IQuestResourceRepository : IRepository
{
    Task CreateAsync(QuestResourceDto dto);
    Task<QuestResourceDto?> FindAsync(Guid id);
    Task UpdateAsync(QuestResourceDto dto);
    Task DeleteAsync(QuestResourceDto dto);
}

public class QuestResourceRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestResourceDbo, QuestResourceDto> converter
) : RepositoryBase<QuestResourceDbo, QuestResourceDto, Guid>(dataContext, converter, x => x.Id), IQuestResourceRepository;