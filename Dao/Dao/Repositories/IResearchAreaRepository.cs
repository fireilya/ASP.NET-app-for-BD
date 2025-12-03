using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IResearchAreaRepository : IRepository
{
    Task CreateAsync(ResearchAreaDto dto);
    Task<ResearchAreaDto?> FindAsync(Guid id);
    Task UpdateAsync(ResearchAreaDto dto);
    Task DeleteAsync(ResearchAreaDto dto);
}

public class ResearchAreaRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<ResearchAreaDbo, ResearchAreaDto> converter
) : RepositoryBase<ResearchAreaDbo, ResearchAreaDto, Guid>(dataContext, converter, x => x.Id), IResearchAreaRepository;