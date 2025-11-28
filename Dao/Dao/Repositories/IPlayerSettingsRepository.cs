using System;
using System.Linq;
using System.Threading.Tasks;
using Core.EFCore;
using Dao.Entities;
using Domain.FlattenDtos;
using Microsoft.EntityFrameworkCore;

namespace Dao.Repositories;

public interface IPlayerSettingsRepository : IRepository
{
    Task CreateAsync(PlayerSettingsDto playerSettingsDto);
    Task<PlayerSettingsDto> ReadByPlayerAsync(Guid playerId);
    Task UpdateAsync(PlayerSettingsDto playerSettingsDto);
}

public class PlayerSettingsRepository(
    ISingletonDataContext dataContext,
    IEntityConverter<PlayerSettingsDbo, PlayerSettingsDto> converter
) : RepositoryBase<PlayerSettingsDbo, PlayerSettingsDto, Guid>(dataContext, converter, x => x.Id),
    IPlayerSettingsRepository
{
    public async Task<PlayerSettingsDto> ReadByPlayerAsync(Guid playerId)
    {
        var playerSettingsDbo = await DataContext.ExecuteQueryAsync<PlayerSettingsDbo, PlayerSettingsDbo?>(query =>
            query.Where(x => x.PlayerId == playerId).SingleOrDefaultAsync()
        );
        return playerSettingsDbo is null
            ? throw new EntityNotFoundException($"Настройки для игрока {playerId} не найдены")
            : Converter.ToDto(playerSettingsDbo);
    }
}