using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IAffectedEntityRepository : IRepository
{
    Task CreateAsync(AffectedEntityDto affectedEntityDto);
    Task<AffectedEntityDto?> FindAsync(Guid affectedEntityId);
    Task ReadAsync(Guid affectedEntityId);
    Task<AffectedEntityDto[]> SelectAsync(Guid[] affectedEntityIds);
    Task UpdateAsync(AffectedEntityDto affectedEntityDto);
    Task DeleteAsync(AffectedEntityDto affectedEntityDto);
}

public class AffectedEntityRepository(
ISingletonDataContext dataContext,
IEntityConverter<AffectedEntityDbo, AffectedEntityDto> converter
) : RepositoryBase<AffectedEntityDbo, AffectedEntityDto, Guid>(dataContext, converter, x => x.Id), IAffectedEntityRepository
{
    public async Task ReadAsync(Guid affectedEntityId)
    {
        var affectedEntityDbo = await DataContext.ReadAsync<AffectedEntityDbo, Guid>(affectedEntityId);
        return Converter.ToDto(affectedEntityDbo);
    }
}