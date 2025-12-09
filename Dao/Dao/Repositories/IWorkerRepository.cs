using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IWorkerRepository : IRepository
{
    Task CreateAsync(WorkerDto workerDto);
    Task<WorkerDto?> FindAsync(Guid workerId);
    Task UpdateAsync(WorkerDto workerDto);
    Task DeleteAsync(WorkerDto workerDto);
}

public class WorkerRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<WorkerDbo, WorkerDto> converter
) : RepositoryBase<WorkerDbo, WorkerDto, Guid>(dataContext, converter, x => x.Id), IWorkerRepository;