using System;
using System.Linq;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface ISubtaskCapacityToolRepository : IRepository
{
    Task CreateAsync(SubtaskCapacityToolDto dto);
    Task<SubtaskCapacityToolDto?> FindAsync(Guid id);
    Task UpdateAsync(SubtaskCapacityToolDto dto);
    Task DeleteAsync(SubtaskCapacityToolDto dto);
    Task<SubtaskCapacityToolDto[]> SelectBySubtaskIdAsync(Guid subtaskId);
    Task<SubtaskCapacityToolDto> ReadBaseBySubtaskIdAsync(Guid subtaskId);
}

public class SubtaskCapacityToolRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<SubtaskCapacityToolDbo, SubtaskCapacityToolDto> converter
) : RepositoryBase<SubtaskCapacityToolDbo, SubtaskCapacityToolDto, Guid>(dataContext, converter, x => x.Id),
    ISubtaskCapacityToolRepository
{
    public async Task<SubtaskCapacityToolDto[]> SelectBySubtaskIdAsync(Guid subtaskId)
    {
        var subtaskCapacityToolDbos =
            await DataContext.ExecuteQueryAsync<SubtaskCapacityToolDbo, SubtaskCapacityToolDbo[]>(query => query
               .Where(x => x.SubtaskId == subtaskId)
               .ToArrayAsync()
            );
        return Converter.ToDto(subtaskCapacityToolDbos);
    }

    public async Task<SubtaskCapacityToolDto> ReadBaseBySubtaskIdAsync(Guid subtaskId)
    {
        var subtaskCapacityToolDbo = await
            DataContext.ExecuteQueryAsync<SubtaskCapacityToolDbo, SubtaskCapacityToolDbo>(query => query
               .Where(x => x.SubtaskId == subtaskId)
               .Where(x => x.ResourceId == null) // Костыль. Запись для подзадачи без ресурса означает пустую руку
               .FirstAsync()
            );
        return Converter.ToDto(subtaskCapacityToolDbo);
    }
}