using System;
using System.Collections.Generic;
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
    Task<Dictionary<Guid, short>> FindToolCapacityMappingForSubtaskAsync(Guid subtaskId);
    Task<short> FindBaseCapacityForSubtaskAsync(Guid subtaskId);
}

public class SubtaskCapacityToolRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<SubtaskCapacityToolDbo, SubtaskCapacityToolDto> converter
) : RepositoryBase<SubtaskCapacityToolDbo, SubtaskCapacityToolDto, Guid>(dataContext, converter, x => x.Id), ISubtaskCapacityToolRepository
{
    public async Task<Dictionary<Guid, short>> FindToolCapacityMappingForSubtaskAsync(Guid subtaskId)
    {
        var toolsCapacity = await
            DataContext.ExecuteQueryAsync<SubtaskCapacityToolDbo, SubtaskCapacityToolDbo[]>(query => query
                .Where(x => x.SubtaskId == subtaskId)
                .ToArrayAsync());
        return toolsCapacity.ToDictionary(x => x.ResourceId, x => x.Capacity);
    }

    public async Task<short> FindBaseCapacityForSubtaskAsync(Guid subtaskId)
    {
        var toolCapacity = await 
            DataContext.ExecuteQueryAsync<SubtaskCapacityToolDbo, SubtaskCapacityToolDbo>(query => query
                .Where(x => x.ResourceId == Guid.Empty)
                .FirstAsync());
        return toolCapacity.Capacity;
    }
}