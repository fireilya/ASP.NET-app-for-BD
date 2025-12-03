using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IEdgeRepository : IRepository
{
    Task CreateAsync(EdgeDto dto);
    Task<EdgeDto?> FindAsync(Guid id);
    Task UpdateAsync(EdgeDto dto);
    Task DeleteAsync(EdgeDto dto);
}

public class EdgeRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<EdgeDbo, EdgeDto> converter
) : RepositoryBase<EdgeDbo,EdgeDto,Guid>(dataContext, converter, x => x.Id), IEdgeRepository;