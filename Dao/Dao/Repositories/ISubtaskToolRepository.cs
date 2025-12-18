using System;
using System.Linq;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface ISubtaskToolRepository : IRepository
{
    Task CreateAsync(SubtaskToolDto dto);
    Task<SubtaskToolDto?> FindAsync(Guid id);
    Task UpdateAsync(SubtaskToolDto dto);
    Task DeleteAsync(SubtaskToolDto dto);
    
    Task<SubtaskToolDto?> FindToolForSubtaskAsync(Guid subtaskId);
}

public class SubtaskToolRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<SubtaskToolDbo, SubtaskToolDto> converter
) : RepositoryBase<SubtaskToolDbo, SubtaskToolDto, Guid>(dataContext, converter, x => x.Id), ISubtaskToolRepository
{
    public async Task<SubtaskToolDto?> FindToolForSubtaskAsync(Guid subtaskId)
    {
        return Converter.ToDto(await DataContext.ExecuteQueryAsync<SubtaskToolDbo, SubtaskToolDbo>(
            query => query
                .Where(x => x.SubtaskId == subtaskId)
                .FirstAsync()));
    }
}