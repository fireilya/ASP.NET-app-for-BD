using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IQuestSourceInfoRepository : IRepository
{
    Task CreateAsync(QuestSourceInfoDto dto);
    Task<QuestSourceInfoDto?> FindAsync(Guid id);
    Task UpdateAsync(QuestSourceInfoDto dto);
    Task DeleteAsync(QuestSourceInfoDto dto);
}

public class QuestSourceInfoRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestSourceInfoDbo, QuestSourceInfoDto> converter
) : RepositoryBase<QuestSourceInfoDbo, QuestSourceInfoDto, Guid>(dataContext, converter, x => x.Id), IQuestSourceInfoRepository;
