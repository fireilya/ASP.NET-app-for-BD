using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.FlattenDtos;

[Table("quest_obstacle")]
public class QuestObstacleDto
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("obstacle_id")]
    public required Guid ObstacleId { get; set; }

    [Column("research_area_id")]
    public required Guid ResearchAreaId { get; set; }
}