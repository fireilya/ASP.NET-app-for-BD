using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IRiskRepository : IRepository
{
    Task CreateAsync(RiskDto dto);
    Task<RiskDto?> FindAsync(Guid id);
    Task UpdateAsync(RiskDto dto);
    Task DeleteAsync(RiskDto dto);
}

public class RiskRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<RiskDbo, RiskDto> converter
) : RepositoryBase<RiskDbo, RiskDto, Guid>(dataContext, converter, x => x.Id), IRiskRepository;