using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoApp.Application.Common.Interfaces;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Todo> TodoItems => Set<Todo>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.HasPostgresExtension("pg_trgm");
    }
}
