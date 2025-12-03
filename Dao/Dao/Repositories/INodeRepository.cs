using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface INodeRepository : IRepository
{
    Task CreateAsync(NodeDto dto);
    Task<NodeDto?> FindAsync(Guid id);
    Task UpdateAsync(NodeDto dto);
    Task DeleteAsync(NodeDto dto);
}

public class NodeRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<NodeDbo, NodeDto> converter
) : RepositoryBase<NodeDbo, NodeDto, Guid>(dataContext, converter, x => x.Id), INodeRepository;