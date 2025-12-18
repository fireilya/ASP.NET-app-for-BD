using System;
using System.Threading.Tasks;
using Dao.Repositories;
using Domain.Scheduler;

namespace Dao.Storages;

public interface IToolStorage
{
    Task<Tool?> GetDomainByIdAsync(Guid id);
    Task UploadDomainAsync(Tool actionArea);
}

public class ToolStorage(
    IQuestResourceRepository questResourceRepository,
    IToolRepository toolRepository) : IToolStorage
{
    public async Task<Tool?> GetDomainByIdAsync(Guid id)
    {
        var resourceDto = await questResourceRepository.FindAsync(id);
        var toolDto = await toolRepository.FindAsync(id);
        // TODO: Обработка null случая
        return new Tool(id, resourceDto!.Name, toolDto!.PathToIcon);
    }

    public Task UploadDomainAsync(Tool actionArea)
    {
        throw new NotImplementedException();
    }
}