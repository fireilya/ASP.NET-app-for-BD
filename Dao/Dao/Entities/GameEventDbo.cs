using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.EFCore;
using Domain.Enumerations;

namespace Dao.Entities;

[Table("event")]
public class GameEventDbo
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("district_id")]
    public required Guid? DistrictId { get; set; }

    [Column("research_area_id")]
    public required Guid ResearchAreaId { get; set; }

    [Column("event_type")]
    public required GameEventType EventType { get; set; }

    [Column("is_positive")]
    public required bool IsPositive { get; set; }

    [Column("name"), StringLength(50)]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("time_delay_in_minute")]
    public required short TimeDelayInMinutes { get; set; }

    [Column("chance"), Range(0, 1)]
    public required float Chance { get; set; }

    [Column("max_occurance_count")]
    public required short MaxOccuranceCount { get; set; }

    [Column("event_data", TypeName = PostgresDataType.Json)]
    public required string EventData { get; set; }
}