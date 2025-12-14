using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface ISubtaskRepository : IRepository
{
    Task CreateAsync(SubtaskDto dto);
    Task<SubtaskDto?> FindAsync(Guid id);
    Task UpdateAsync(SubtaskDto dto);
    Task DeleteAsync(SubtaskDto dto);
}

public class SubtaskRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<SubtaskDbo, SubtaskDto> converter
) : RepositoryBase<SubtaskDbo, SubtaskDto, Guid>(dataContext, converter, x => x.Id), ISubtaskRepository;