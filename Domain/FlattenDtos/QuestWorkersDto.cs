using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.FlattenDtos;
public class QuestWorkersDbo
{
    public required Guid Id { get; set; }
    public required Guid WorkerId { get; set; }
    public required Guid QuestId { get; set; }
}