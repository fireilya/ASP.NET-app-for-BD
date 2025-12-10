using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IQuestWorkerRepository : IRepository
{
    Task CreateAsync(QuestWorkerDto dto);
    Task<QuestWorkerDto?> FindAsync(Guid id);
    Task UpdateAsync(QuestWorkerDto dto);
    Task DeleteAsync(QuestWorkerDto dto);
}

public class QuestWorkerRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestWorkerDbo, QuestWorkerDto> converter
) : RepositoryBase<QuestWorkerDbo, QuestWorkerDto, Guid>(dataContext, converter, x => x.Id), IQuestWorkerRepository;