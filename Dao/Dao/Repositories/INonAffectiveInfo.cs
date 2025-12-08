using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface INonAffectiveInfoRepository : IRepository
{
    Task CreateAsync(NonAffectiveInfoDto nonAffectiveInfoDto);
    Task<NonAffectiveInfoDto?> FindAsync(Guid briefInfoId, NonAffectiveInfoType type);
    Task ReadAsync(Guid briefInfoId, NonAffectiveInfoType type);
    Task UpdateAsync(NonAffectiveInfoDto nonAffectiveInfoDto);
    Task DeleteAsync(NonAffectiveInfoDto nonAffectiveInfoDto);
}

public class NonAffectiveInfoRepository(
ISingletonDataContext dataContext,
IEntityConverter<NonAffectiveInfoDbo, NonAffectiveInfoDto> converter
) : RepositoryBase<NonAffectiveInfoDbo, NonAffectiveInfoDto, object[]>(dataContext, converter, x => new object[] { x.BriefInfoId, x.NonAffectiveInfoType }), INonAffectiveInfoRepository
{
    public async Task<NonAffectiveInfoDto?> FindAsync(Guid briefInfoId, NonAffectiveInfoType type)
    {
        var dbo = await DataContext.Set()
        .Where(x => x.BriefInfoId == briefInfoId && x.NonAffectiveInfoType == type)
        .FirstOrDefaultAsync();
        return dbo == null ? null : Converter.ToDto(dbo);
    }
    public async Task ReadAsync(Guid briefInfoId, NonAffectiveInfoType type)
    {
        var dbo = await DataContext.Set()
        .Where(x => x.BriefInfoId == briefInfoId && x.NonAffectiveInfoType == type)
        .FirstAsync();
        return Converter.ToDto(dbo);
    }
}