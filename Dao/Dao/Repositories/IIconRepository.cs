using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;

namespace Dao.Repositories;

public interface IIconRepository : IRepository
{
    Task CreateOrUpdateAsync(IconDto dto);
    Task<IconDto?> FindAsync(string path);
}

public class IconRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<IconDbo, IconDto> converter
) : RepositoryBase<IconDbo, IconDto, string>(dataContext, converter, x => x.Path), IIconRepository;