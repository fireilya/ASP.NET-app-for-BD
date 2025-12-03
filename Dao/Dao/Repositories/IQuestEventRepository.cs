using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IQuestEventRepository : IRepository
{
    Task CreateAsync(QuestEventDto dto);
    Task<QuestEventDto?> FindAsync(Guid id);
    Task UpdateAsync(QuestEventDto dto);
    Task DeleteAsync(QuestEventDto dto);
}

public class QuestEventRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestEventDbo, QuestEventDto> converter
) : RepositoryBase<QuestEventDbo, QuestEventDto, Guid>(dataContext, converter, x => x.Id), IQuestEventRepository;