using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IPassedQuestsRepository : IRepository
{
    Task CreateAsync(PassedQuestsDto dto);
    Task<PassedQuestsDto?> FindAsync(Guid id);
    Task UpdateAsync(PassedQuestsDto dto);
    Task DeleteAsync(PassedQuestsDto dto);
}

public class PassedQuestsRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<PassedQuestsDbo, PassedQuestsDto> converter
) : RepositoryBase<PassedQuestsDbo, PassedQuestsDto, Guid>(dataContext, converter, x => x.Id), IPassedQuestsRepository;