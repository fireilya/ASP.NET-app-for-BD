using Dao.Repositories;
using Domain.Enumerations;
using Domain.FlattenDtos;
using Domain.Scheduler;

namespace GameService.Storages;

public interface IToolStorage
{
    Task<Tool?> FindAsync(Guid id);
    Task SaveAsync(Tool tool);
}

public class ToolStorage(
    IQuestResourceRepository questResourceRepository,
    IToolRepository toolRepository,
    ILogger<ToolStorage> logger
) : IToolStorage
{
    public async Task<Tool?> FindAsync(Guid id)
    {
        var resourceDto = await questResourceRepository.FindAsync(id);
        var toolDto = await toolRepository.FindAsync(id);
        if (resourceDto is null || toolDto is null)
        {
            logger.LogInformation("Не нашли ресурс или инструмент");
            return null;
        }

        return new Tool(id, resourceDto.QuestId, resourceDto.Name, toolDto.PathToIcon);
    }

    public async Task SaveAsync(Tool tool)
    {
        await toolRepository.CreateAsync(new ToolDto(tool.Id, tool.PathToIcon));
        await questResourceRepository.CreateAsync(
            new QuestResourceDto(tool.Id, tool.QuestId, tool.Name, ResourceType.Tool)
        );
    }
}