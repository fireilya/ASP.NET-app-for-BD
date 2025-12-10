using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IToolRepository : IRepository
{
    Task CreateAsync(ToolDto dto);
    Task<ToolDto?> FindAsync(Guid id);
    Task UpdateAsync(ToolDto dto);
    Task DeleteAsync(ToolDto dto);
}

public class ToolRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<ToolDbo, ToolDto> converter
) : RepositoryBase<ToolDbo, ToolDto, Guid>(dataContext, converter, x => x.Id), IToolRepository;