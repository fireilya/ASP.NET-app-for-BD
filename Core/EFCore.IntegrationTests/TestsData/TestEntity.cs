using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.EFCore.IntegrationTests.TestsData;

[Table("test_entities")]
public class TestEntity
{
    [Column("id"), Key]
    public required Guid Id { get; set; }

    [Column("name"), MaxLength(64)]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("state")]
    public required TestEntityState State { get; set; }

    [Column("random_number_int4")]
    public int RandomNumber { get; set; }

    [Column("random_number_int8")]
    public long LongRandomNumber { get; set; }

    [Column("test_bool")]
    public bool TestBool { get; set; }

    [Column("created_at_utc")]
    public required DateTime CreatedAtUtc { get; set; }

    [Column("interval")]
    public required TimeSpan Interval { get; set; }
}