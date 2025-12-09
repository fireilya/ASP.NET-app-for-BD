using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface INeutralizerRepository : IRepository
{
    Task CreateAsync(NeutralizerDto dto);
    Task<NeutralizerDto?> FindAsync(Guid id);
    Task UpdateAsync(NeutralizerDto dto);
    Task DeleteAsync(NeutralizerDto dto);
}

public class NeutralizerRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<NeutralizerDbo, NeutralizerDto> converter
) : RepositoryBase<NeutralizerDbo, NeutralizerDto, Guid>(dataContext, converter, x => x.Id), INeutralizerRepository;