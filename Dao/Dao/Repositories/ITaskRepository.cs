using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface ITaskRepository : IRepository
{
    Task CreateAsync(TaskDto dto);
    Task<TaskDto?> FindAsync(Guid id);
    Task UpdateAsync(TaskDto dto);
    Task DeleteAsync(TaskDto dto);
}

public class TaskRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<TaskDbo, TaskDto> converter
) : RepositoryBase<TaskDbo, TaskDto, Guid>(dataContext, converter, x => x.Id), ITaskRepository;