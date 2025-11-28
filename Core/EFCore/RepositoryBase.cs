using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.EFCore;

public abstract class RepositoryBase<TDbo, TDto, TPrimaryKey>(
    ISingletonDataContext dataContext,
    IEntityConverter<TDbo, TDto> converter,
    Expression<Func<TDbo, TPrimaryKey>> keyPicker
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

    public async Task<TDto[]> SelectAsync(TPrimaryKey[] primaryKeys) =>
        converter.ToDto(await dataContext.SelectAsync(keyPicker, primaryKeys));

    public Task UpdateAsync(TDto dto) => dataContext.UpdateAsync(converter.ToDbo(dto));

    public Task DeleteAsync(TDto dto) => dataContext.DeleteAsync(converter.ToDbo(dto));

    public Task DeleteAsync(params TPrimaryKey[] keys) => dataContext.DeleteAsync(keyPicker, keys);
}