using Domain.Common;
using Domain.Common.Enums;

namespace Domain.Entities;

public class Todo : BaseAuditableEntity
{
    public required string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TodoStatus Status { get; set; } = TodoStatus.Opened;
    public Priority Priority { get; set; } = Priority.Normal;
    public bool IsUrgent { get; set; } = false;
}
