using System.Buffers.Text;
using Dao.Repositories;
using Domain.FlattenDtos;
using GameService.Controllers;

namespace GameService.Storages;

public interface IIconStorage
{
    Task<IconApiModel?> FindAsync(string path);
    Task SaveAsync(IconApiModel icon);
}

class IconStorage(IIconRepository iconRepository) : IIconStorage
{
    public async Task<IconApiModel?> FindAsync(string path)
    {
        var iconDto = await iconRepository.FindAsync(path);
        return iconDto == null 
            ? null
            : new IconApiModel(iconDto.Path, Convert.ToBase64String(iconDto.Body));
    }

    public async Task SaveAsync(IconApiModel icon)
    {
        await iconRepository.CreateOrUpdateAsync(new IconDto(icon.Path, Convert.FromBase64String(icon.Body)));
    }
}