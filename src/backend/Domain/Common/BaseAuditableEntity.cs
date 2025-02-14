using TodoApp.Domain.Common;

namespace Domain.Common;

public class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public bool? IsArchived { get; set; }
}
