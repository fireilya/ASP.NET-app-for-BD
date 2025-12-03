using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("quest_obstacle")]
public class QuestObstacleDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("research_area_id")]
    public required Guid ResearchAreaId { get; set; }

    [Column("name"), StringLength(50)]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("time_delay_in_minute")]
    public required short TimeDelayInMinutes { get; set; }

    [Column("max_instance")]
    public required short MaxInstance { get; set; }

    [Column("path_to_icon"), StringLength(50)]
    public required string PathToIcon { get; set; }
}