using Domain.Entities;

namespace TodoApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Todo> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
