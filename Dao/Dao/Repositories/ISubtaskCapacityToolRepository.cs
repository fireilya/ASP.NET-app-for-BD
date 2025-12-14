using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface ISubtaskCapacityToolRepository : IRepository
{
    Task CreateAsync(SubtaskCapacityToolDto dto);
    Task<SubtaskCapacityToolDto?> FindAsync(Guid id);
    Task UpdateAsync(SubtaskCapacityToolDto dto);
    Task DeleteAsync(SubtaskCapacityToolDto dto);
}

public class SubtaskCapacityToolRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<SubtaskCapacityToolDbo, SubtaskCapacityToolDto> converter
) : RepositoryBase<SubtaskCapacityToolDbo, SubtaskCapacityToolDto, Guid>(dataContext, converter, x => x.Id), ISubtaskCapacityToolRepository;