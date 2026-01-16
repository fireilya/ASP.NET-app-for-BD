using Dao.Repositories;
using Domain.FlattenDtos;
using Domain.Scheduler;

namespace GameService.Storages;

public interface IActionAreaStorage
{
    Task<ActionArea?> FindAsync(Guid id);
    Task StoreAsync(ActionArea actionArea);
}

public class ActionAreaStorage(
    IActionAreaRepository actionAreaRepository,
    ILocationRepository locationRepository,
    ITaskRepository taskRepository,
    ISubtaskRepository subtaskRepository,
    ISubtaskToolRepository subtaskToolRepository,
    ISubtaskCapacityToolRepository subtaskCapacityToolRepository,
    IRiskRepository riskRepository,
    INeutralizerRepository neutralizerRepository
) : IActionAreaStorage
{
    public async Task<ActionArea?> FindAsync(Guid id)
    {
        var actionAreaDto = await actionAreaRepository.FindAsync(id);
        // TODO: Обработка null случая
        var actionAreaLocations = await BuildLocationsArrayForActionAreaAsync(actionAreaDto!.Id);
        return new ActionArea(actionAreaDto.Id, actionAreaDto.PathToTexture, actionAreaDto.Name, actionAreaLocations);
    }

    private async Task<Location[]> BuildLocationsArrayForActionAreaAsync(Guid actionAreaId)
    {
        var locationsDto = await locationRepository.SelectByActionAreaIdAsync(actionAreaId);
        var answer = new List<Location>();
        foreach (var dto in locationsDto)
        {
            var locationTasks = await BuildTasksArrayForLocationAsync(dto.Id);
            var locationRisk = await BuildRiskOnLocation(dto.Id);
            answer.Add(new Location(dto.Id, dto.Name, dto.PathToIcon, locationTasks, locationRisk, dto.MappingKey));
        }

        return answer.ToArray();
    }

    private async Task<GameTask[]> BuildTasksArrayForLocationAsync(Guid locationId)
    {
        var tasksDto = await taskRepository.SelectByLocationIdAsync(locationId);
        var answer = new List<GameTask>();
        foreach (var dto in tasksDto)
        {
            var subtasks = await BuildSubtasksArrayForTaskAsync(dto.Id);
            answer.Add(new GameTask(dto.Id, dto.Name, dto.Target, dto.DayLimit, subtasks, dto.IsTrue));
        }

        return answer.ToArray();
    }

    private async Task<Subtask[]> BuildSubtasksArrayForTaskAsync(Guid taskId)
    {
        var subtasksDto = await subtaskRepository.SelectByTaskIdAsync(taskId);
        var answer = new List<Subtask>();
        foreach (var dto in subtasksDto.OrderBy(x => x.Order))
        {
            if (dto.IsUseCapacityTool)
            {
                var baseCapacity = await subtaskCapacityToolRepository.ReadBaseBySubtaskIdAsync(dto.Id);
                var toolCapacityDictionary = await subtaskCapacityToolRepository.SelectBySubtaskIdAsync(dto.Id);
                var capacityByResource = toolCapacityDictionary
                   .Where(x => x.ResourceId is not null)
                   .ToDictionary(x => x.ResourceId!.Value, x => x.Capacity);
                var subtask = new CapacitySubtask(
                    dto.Id,
                    dto.Name,
                    dto.BaseEffectiveness,
                    dto.Order,
                    dto.IsUseCapacityTool,
                    baseCapacity.Capacity,
                    capacityByResource
                );
                answer.Add(subtask);
                continue;
            }

            var subtaskToolDto = await subtaskToolRepository.FindBySubtaskIdAsync(dto.Id);
            // TODO: Обработка null случая
            answer.Add(
                new ProcessSubtask(
                    dto.Id,
                    dto.Name,
                    dto.BaseEffectiveness,
                    dto.Order,
                    dto.IsUseCapacityTool,
                    subtaskToolDto!.ResourceId
                )
            );
        }

        return answer.ToArray();
    }

    private async Task<Risk> BuildRiskOnLocation(Guid locationId)
    {
        var riskDto = await riskRepository.FindRiskForLocationAsync(locationId);
        
        // TODO: Обработка null случая
        return new Risk(
            riskDto.Id,
            riskDto.Name,
            riskDto.PathToIcon,
            riskDto.Description,
            riskDto.HappenedMessage,
            riskDto.BadInfluenceMessage,
            riskDto.NeutralizerId
        );
    }

    public async Task StoreAsync(ActionArea actionArea)
    {
        await actionAreaRepository.CreateAsync(
            new ActionAreaDto(actionArea.Id, actionArea.PathToTexture, actionArea.Name)
        );
        foreach (var location in actionArea.Locations)
        {
            await locationRepository.CreateAsync(
                new LocationDto(location.Id, actionArea.Id, location.Name, location.PathToIcon, location.MappingKey)
            );

            foreach (var task in location.Tasks)
            {
                await taskRepository.CreateAsync(
                    new TaskDto(
                        task.Id,
                        location.Id,
                        task.Name,
                        task.Target,
                        task.DayLimit,
                        task.IsTrue
                    )
                );

                for (var i = 0; i < task.Subtasks.Length; i++)
                {
                    var subtask = task.Subtasks[i];

                    await subtaskRepository.CreateAsync(
                        new SubtaskDto(
                            subtask.Id,
                            subtask.GameTask.Id,
                            subtask.Name,
                            (short)i,
                            subtask.BaseEfficiency,
                            subtask.IsUseCapacityTool
                        )
                    );
                }
            }
        }
    }
}