using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dao.Entities;

[Table("brief_info")]
public class BriefInfoDbo
{
	[Column("brief_info_id"), Key]
	public required Guid Id { get; set; }

	[Column("quest_id")]
	public required Guid QuestId { get; set; }

	[Column("is_true")]
	public required bool IsTrue { get; set; }

	[Column("affected_entity_id")]
	public required Guid AffectedEntityId { get; set; }

	[Column("text")]
	public required string Content { get; set; }
}