using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.EFCore.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Core.EFCore;

public class DataContext(
    IDbContextModelConfigurator modelConfigurator,
    DbContextOptions dbContextOptions,
    ILogger<DataContext> logger
) : DbContext(dbContextOptions), IDataContext
{
    // Штука чисто для дебага, можно понаблюдать за работой пула контекстов
    // ReSharper disable once UnusedMember.Local
    private readonly int contextNumber = DataContextCounter.GetContextNumber(logger);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelConfigurator.Configure(modelBuilder);
    }

    public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : class
    {
        await AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task InsertRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class
    {
        // ReSharper disable once CoVariantArrayConversion
        await AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public async Task<TEntity?> FindAsync<TEntity, TKey>(TKey primaryKey) where TEntity : class
        => await FindAsync<TEntity>(primaryKey);

    public async Task<TEntity> ReadAsync<TEntity, TKey>(TKey primaryKey) where TEntity : class
        => await FindAsync<TEntity, TKey>(primaryKey) ??
           throw new EntityNotFoundException(
               $"Entity {typeof(TEntity).Name} not found with primary key {primaryKey}"
           );

    public async Task<TEntity[]> SelectAsync<TEntity, TKey>(
        Expression<Func<TEntity, TKey>> propertyPicker,
        params TKey[] values
    ) where TEntity : class
        => await GetTable<TEntity>().WhereContains(propertyPicker, values).ToArrayAsync();

    public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        Update(entity);
        await SaveChangesAsync();
    }

    public Task UpdatePropertiesAsync<TEntity, TKey>(
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setProperties,
        Expression<Func<TEntity, TKey>> propertyPicker,
        params TKey[] values
    ) where TEntity : class
        => Set<TEntity>()
           .WhereContains(propertyPicker, values)
           .ExecuteUpdateAsync(setProperties);

    public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
    {
        Remove(entity);
        await SaveChangesAsync();
    }

    public Task DeleteAsync<TEntity, TKey>(Expression<Func<TEntity, TKey>> propertyPicker, params TKey[] values)
        where TEntity : class
        => Set<TEntity>()
           .WhereContains(propertyPicker, values)
           .ExecuteDeleteAsync();

    public IQueryable<TEntity> GetTable<TEntity>() where TEntity : class => Set<TEntity>().AsNoTracking();
}