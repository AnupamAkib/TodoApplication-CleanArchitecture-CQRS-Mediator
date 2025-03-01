using Domain.Entities;
using Infrastructure.Data;
using Testcontainers.PostgreSql;

namespace Application.UnitTests.Common;

public class ApplicationDbContextFactory
{
    public static ApplicationDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new ApplicationDbContext(options);

        context.Database.EnsureCreated();

        AddTodoItems(context);

        context.SaveChanges();

        return context;
    }

    public static ApplicationDbContext CreateTestContainerDB()
    {
        var _postgresContainer = new PostgreSqlBuilder()
            .WithDatabase("testdb")
            .WithUsername("testuser")
            .WithPassword("testpassword")
            .Build();

        _postgresContainer.StartAsync().Wait();

        var connectionString = _postgresContainer.GetConnectionString();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        var context = new ApplicationDbContext(options);

        context.Database.EnsureCreated();

        AddTodoItems(context);

        context.SaveChanges();

        return context;
    }

    private static void AddTodoItems(ApplicationDbContext context)
    {
        context.AddRange(new Todo
        {
            Title = "Test1",
        });
    }

    public static void Destroy(ApplicationDbContext context)
    {
        context.Database.EnsureDeleted();

        context.Dispose();
    }
}
