using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface ISubtaskToolRepository : IRepository
{
    Task CreateAsync(SubtaskToolDto dto);
    Task<SubtaskToolDto?> FindAsync(Guid id);
    Task UpdateAsync(SubtaskToolDto dto);
    Task DeleteAsync(SubtaskToolDto dto);
}

public class SubtaskToolRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<SubtaskToolDbo, SubtaskToolDto> converter
) : RepositoryBase<SubtaskToolDbo, SubtaskToolDto, Guid>(dataContext, converter, x => x.Id), ISubtaskToolRepository;