using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IQuestionsInfoRepository : IRepository
{
    Task CreateAsync(QuestionsInfoDto dto);
    Task<QuestionsInfoDto?> FindAsync(Guid id);
    Task UpdateAsync(QuestionsInfoDto dto);
    Task DeleteAsync(QuestionsInfoDto dto);
}

public class QuestionsInfoRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<QuestionsInfoDbo, QuestionsInfoDto> converter
) : RepositoryBase<QuestionsInfoDbo, QuestionsInfoDto, Guid>(dataContext, converter, x => x.Id), IQuestionsInfoRepository;