using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IInfoSourceRepository : IRepository
{
    Task CreateAsync(InfoSourceDto dto);
    Task<InfoSourceDto?> FindAsync(Guid id);
    Task UpdateAsync(InfoSourceDto dto);
    Task DeleteAsync(InfoSourceDto dto);
}

public class InfoSourceRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<InfoSourceDbo, InfoSourceDto> converter
) : RepositoryBase<InfoSourceDbo, InfoSourceDto, Guid>(dataContext, converter, x => x.Id), IInfoSourceRepository;