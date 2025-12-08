using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IBriefInfoRepository : IRepository
{
    Task CreateAsync(BriefInfoDto briefInfoDto);
    Task<BriefInfoDto?> FindAsync(Guid briefInfoId);
    Task<BriefInfoDto> ReadAsync(Guid briefInfoId);
    Task<BriefInfoDto[]> SelectAsync(Guid[] briefInfoIds);
    Task UpdateAsync(BriefInfoDto briefInfoDto);
    Task DeleteAsync(BriefInfoDto briefInfoDto);
}

public class BriefInfoRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<BriefInfoDbo, BriefInfoDto> converter
) : RepositoryBase<BriefInfoDbo, BriefInfoDto, Guid>(dataContext, converter, x => x.Id), IBriefInfoRepository
{
    public async Task<BriefInfoDto> ReadAsync(Guid briefInfoId)
    {
        var briefInfoDbo = await DataContext.ReadAsync<BriefInfoDbo, Guid>(briefInfoId);
        return Converter.ToDto(briefInfoDbo);
    }
}