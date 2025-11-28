using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IGameEventRepository : IRepository
{
    Task CreateAsync(GameEventDto gameEvent);
    Task<GameEventDto?> FindAsync(Guid gameEventId);
    Task<GameEventDto[]> SelectAsync(Guid[] gameEventIds);
    Task UpdateAsync(GameEventDto gameEventDto);
    Task DeleteAsync(GameEventDto gameEventDto);
    Task DeleteAsync(Guid[] gameEventIds);
}

public class GameEventRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<GameEventDbo, GameEventDto> converter
) : RepositoryBase<GameEventDbo, GameEventDto, Guid>(dataContext, converter, x => x.Id), IGameEventRepository;