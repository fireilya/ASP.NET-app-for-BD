using System;
using System.Linq;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface ITaskRepository : IRepository
{
    Task CreateAsync(TaskDto dto);
    Task<TaskDto?> FindAsync(Guid id);
    Task UpdateAsync(TaskDto dto);
    Task DeleteAsync(TaskDto dto);
    
    Task<TaskDto[]> FindAllForLocationAsync(Guid locationId);
}

public class TaskRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<TaskDbo, TaskDto> converter
) : RepositoryBase<TaskDbo, TaskDto, Guid>(dataContext, converter, x => x.Id), ITaskRepository
{
    public async Task<TaskDto[]> FindAllForLocationAsync(Guid locationId)
    {
        var tasks = await DataContext.ExecuteQueryAsync<TaskDbo, TaskDbo[]>(
            query => query
            .Where(x => x.LocationId == locationId)
            .ToArrayAsync());
        return Converter.ToDto(tasks);
    }
}