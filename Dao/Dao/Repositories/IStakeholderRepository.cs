using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IStakeholderRepository : IRepository
{
    Task CreateAsync(StakeholderDto dto);
    Task<StakeholderDto?> FindAsync(Guid id);
    Task UpdateAsync(StakeholderDto dto);
    Task DeleteAsync(StakeholderDto dto);
}

public class StakeholderRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<StakeholderDbo, StakeholderDto> converter
) : RepositoryBase<StakeholderDbo, StakeholderDto, Guid>(dataContext, converter, x => x.Id), IStakeholderRepository;