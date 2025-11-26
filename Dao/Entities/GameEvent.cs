using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.EFCore;
using Domain.Enumerations;

namespace Dao.Entities;

[Table("event")]
public class GameEvent
{
    [Column("id", TypeName = PostgresDataType.Guid), Key]
    public required Guid Id { get; set; }

    [Column("district_id", TypeName = PostgresDataType.Guid)]
    public required Guid? DistrictId { get; set; }

    [Column("research_area_id", TypeName = PostgresDataType.Guid)]
    public required Guid ResearchAreaId { get; set; }

    [Column("event_type", TypeName = PostgresDataType.Enum)]
    public required GameEventType EventType { get; set; }

    [Column("is_positive", TypeName = PostgresDataType.Bool)]
    public required bool IsPositive { get; set; }

    [Column("name", TypeName = PostgresDataType.Text)]
    public required string Name { get; set; }

    [Column("description", TypeName = PostgresDataType.Text)]
    public required string Description { get; set; }

    [Column("time_delay_in_minute", TypeName = PostgresDataType.Short)]
    public required short TimeDelayInMinutes { get; set; }

    [Column("chance", TypeName = PostgresDataType.Float), Range(0, 1)]
    public required float Chance { get; set; }

    [Column("max_occurance_count", TypeName = PostgresDataType.Short)]
    public required short MaxOccuranceCount { get; set; }

    [Column("event_data", TypeName = PostgresDataType.Json)]
    public required string EventData { get; set; }
}