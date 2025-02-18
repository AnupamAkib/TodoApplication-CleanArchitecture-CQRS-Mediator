using Domain.Common;

namespace Domain.Entities;

public class User : BaseAuditableEntity
{
    public required Guid UserId { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public string? ProfilePicture { get; set; } = null;
}
