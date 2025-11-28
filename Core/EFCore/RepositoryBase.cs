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
    protected ISingletonDataContext DataContext { get; } = dataContext;
    protected IEntityConverter<TDbo, TDto> Converter { get; } = converter;

    public Task CreateAsync(TDto dto) => DataContext.InsertAsync(Converter.ToDbo(dto));

    public async Task<TDto?> FindAsync(TPrimaryKey key)
    {
        var foundDbo = await DataContext.FindAsync<TDbo, TPrimaryKey>(key);
        return foundDbo is null ? null : Converter.ToDto(foundDbo);
    }

    public async Task<TDto[]> SelectAsync(TPrimaryKey[] primaryKeys) =>
        Converter.ToDto(await DataContext.SelectAsync(keyPicker, primaryKeys));

    public Task UpdateAsync(TDto dto) => DataContext.UpdateAsync(Converter.ToDbo(dto));

    public Task DeleteAsync(TDto dto) => DataContext.DeleteAsync(Converter.ToDbo(dto));

    public Task DeleteAsync(params TPrimaryKey[] keys) => DataContext.DeleteAsync(keyPicker, keys);
}