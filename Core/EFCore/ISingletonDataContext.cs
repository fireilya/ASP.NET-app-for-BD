using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.EFCore;

public interface ISingletonDataContext
{
    Task InsertAsync<TEntity>(TEntity entity) where TEntity : class;
    Task InsertRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class;
    Task<TEntity?> FindAsync<TEntity, TKey>(TKey primaryKey) where TEntity : class;
    Task<TEntity> ReadAsync<TEntity, TKey>(TKey primaryKey) where TEntity : class;

    Task<TEntity[]> SelectAsync<TEntity, TKey>(
        Expression<Func<TEntity, TKey>> propertyPicker,
        params TKey[] values
    ) where TEntity : class;

    Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

    Task UpdatePropertiesAsync<TEntity, TKey>(
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setProperties,
        Expression<Func<TEntity, TKey>> propertyPicker,
        params TKey[] values
    ) where TEntity : class;

    Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;

    Task DeleteAsync<TEntity, TKey>(Expression<Func<TEntity, TKey>> propertyPicker, params TKey[] values)
        where TEntity : class;

    Task<TResult> ExecuteQueryAsync<TEntity, TResult>(Func<IQueryable<TEntity>, Task<TResult>> getResult)
        where TEntity : class;
}

public class SingletonDataContext(
    IDataContextFactory dataContextFactory
) : ISingletonDataContext
{
    public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        await dataContext.InsertAsync(entity);
    }

    public async Task InsertRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        await dataContext.InsertRangeAsync(entities);
    }

    public async Task<TEntity?> FindAsync<TEntity, TKey>(TKey primaryKey) where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        return await dataContext.FindAsync<TEntity, TKey>(primaryKey);
    }

    public async Task<TEntity> ReadAsync<TEntity, TKey>(TKey primaryKey) where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        return await dataContext.ReadAsync<TEntity, TKey>(primaryKey);
    }

    public async Task<TEntity[]> SelectAsync<TEntity, TKey>(
        Expression<Func<TEntity, TKey>> propertyPicker,
        params TKey[] values
    ) where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        return await dataContext.SelectAsync(propertyPicker, values);
    }

    public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        await dataContext.UpdateAsync(entity);
    }

    public async Task UpdatePropertiesAsync<TEntity, TKey>(
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setProperties,
        Expression<Func<TEntity, TKey>> propertyPicker,
        params TKey[] values
    ) where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        await dataContext.UpdatePropertiesAsync(setProperties, propertyPicker, values);
    }

    public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        await dataContext.DeleteAsync(entity);
    }

    public async Task DeleteAsync<TEntity, TKey>(Expression<Func<TEntity, TKey>> propertyPicker, params TKey[] values)
        where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        await dataContext.DeleteAsync(propertyPicker, values);
    }

    public async Task<TResult> ExecuteQueryAsync<TEntity, TResult>(Func<IQueryable<TEntity>, Task<TResult>> getResult)
        where TEntity : class
    {
        await using var dataContext = dataContextFactory.Create();
        return await getResult(dataContext.GetTable<TEntity>());
    }
}