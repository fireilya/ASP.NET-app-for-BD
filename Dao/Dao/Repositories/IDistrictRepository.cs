using System;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Converters;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IDistrictRepository
{
    Task CreateAsync(DistrictDto districtDto);
    Task<DistrictDto?> FindAsync(Guid districtId);
    Task UpdateAsync(DistrictDto districtDto);
    Task DeleteAsync(DistrictDto districtDto);
}

public class DistrictRepository(
    ISingletonDataContext dataContext,
    IDistrictConverter converter
) : RepositoryBase<DistrictDbo, DistrictDto, Guid>(dataContext, converter, x => x.Id), IDistrictRepository;