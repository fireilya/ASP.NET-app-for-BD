using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IInfoSourceLevelRepository : IRepository
{
    Task CreateAsync(InfoSourceLevelDto dto);
    Task<InfoSourceLevelDto?> FindAsync(Guid id);
    Task UpdateAsync(InfoSourceLevelDto dto);
    Task DeleteAsync(InfoSourceLevelDto dto);
}

public class InfoSourceLevelRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<InfoSourceLevelDbo, InfoSourceLevelDto> converter
) : RepositoryBase<InfoSourceLevelDbo, InfoSourceLevelDto, Guid>(dataContext, converter, x => x.Id), IInfoSourceLevelRepository;