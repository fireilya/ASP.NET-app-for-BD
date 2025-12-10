using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface ISaveRepository : IRepository
{
    Task CreateAsync(SaveDto dto);
    Task<SaveDto?> FindAsync(Guid id);
    Task UpdateAsync(SaveDto dto);
    Task DeleteAsync(SaveDto dto);
}

public class SaveRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<SaveDbo, SaveDto> converter
) : RepositoryBase<SaveDbo, SaveDto, Guid>(dataContext, converter, x => x.Id), ISaveRepository;