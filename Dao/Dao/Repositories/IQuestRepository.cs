using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IQuestRepository : IRepository
{
    Task CreateAsync(QuestDto dto);
    Task<QuestDto?> FindAsync(Guid id);
    Task UpdateAsync(QuestDto dto);
    Task DeleteAsync(QuestDto dto);
}

public class QuestRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestDbo, QuestDto> converter
) : RepositoryBase<QuestDbo, QuestDto, Guid>(dataContext, converter, x => x.Id), IQuestRepository;