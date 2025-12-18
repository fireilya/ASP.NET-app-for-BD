using System;
using System.Linq;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface ISubtaskRepository : IRepository
{
    Task CreateAsync(SubtaskDto dto);
    Task<SubtaskDto?> FindAsync(Guid id);
    Task UpdateAsync(SubtaskDto dto);
    Task DeleteAsync(SubtaskDto dto);
    
    Task<SubtaskDto[]> FindAllForTaskAsync(Guid taskId);
}

public class SubtaskRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<SubtaskDbo, SubtaskDto> converter
) : RepositoryBase<SubtaskDbo, SubtaskDto, Guid>(dataContext, converter, x => x.Id), ISubtaskRepository
{
    public async Task<SubtaskDto[]> FindAllForTaskAsync(Guid taskId)
    {
        var subtasks = await DataContext.ExecuteQueryAsync<SubtaskDbo, SubtaskDbo[]>(query => query
            .Where(x => x.AffectedEntityId == taskId)
            .OrderBy(x => x.Order)
            .ToArrayAsync());
        return Converter.ToDto(subtasks);
    }
}