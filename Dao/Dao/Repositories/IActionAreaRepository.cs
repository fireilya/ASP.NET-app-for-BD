using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IActionAreaRepository : IRepository
{
    Task CreateAsync(ActionAreaDto dto);
    Task<ActionAreaDto?> FindAsync(Guid id);
    Task UpdateAsync(ActionAreaDto dto);
    Task DeleteAsync(ActionAreaDto dto);
}

public class ActionAreaRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<ActionAreaDbo, ActionAreaDto> converter
) : RepositoryBase<ActionAreaDbo, ActionAreaDto, Guid>(dataContext, converter, x => x.Id), IActionAreaRepository;