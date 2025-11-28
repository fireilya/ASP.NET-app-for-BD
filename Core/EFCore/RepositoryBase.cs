using System.Threading.Tasks;

namespace Core.EFCore;

public abstract class RepositoryBase<TDbo, TDto, TPrimaryKey>(
    ISingletonDataContext dataContext,
    IEntityConverter<TDbo, TDto> converter
)
    where TDbo : class
    where TDto : class
{
    public Task CreateAsync(TDto dto) => dataContext.InsertAsync(converter.ToDbo(dto));

    public async Task<TDto?> FindAsync(TPrimaryKey key)
    {
        var foundDbo = await dataContext.FindAsync<TDbo, TPrimaryKey>(key);
        return foundDbo is null ? null : converter.ToDto(foundDbo);
    }
}