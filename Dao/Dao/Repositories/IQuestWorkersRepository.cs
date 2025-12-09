using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IQuestWorkersRepository : IRepository
{
    Task CreateAsync(QuestWorkersDto dto);
    Task<QuestWorkersDto?> FindAsync(Guid id);
    Task UpdateAsync(QuestWorkersDto dto);
    Task DeleteAsync(QuestWorkersDto dto);
}

public class WorkerRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestWorkersDbo, QuestWorkersDto> converter
) : RepositoryBase<QuestWorkersDbo, QuestWorkersDto, Guid>(dataContext, converter, x => x.Id), IQuestWorkersRepository;