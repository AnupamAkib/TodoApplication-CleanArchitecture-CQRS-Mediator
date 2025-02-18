using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using TodoApp.Domain.Common;

namespace Domain.Common;

public class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public bool? IsArchived { get; set; }

    [ForeignKey(nameof(CreatedBy))]
    public virtual User? CreatedByUser { get; set; }

    [ForeignKey(nameof(LastModifiedBy))]
    public virtual User? LastModifiedByUser { get; set; }
}
