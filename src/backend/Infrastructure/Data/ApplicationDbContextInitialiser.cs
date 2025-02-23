using Domain.Common.Enums;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var initializer = services.GetRequiredService<ApplicationDbContextInitialiser>();
            await initializer.InitialiseAsync();
            await initializer.SeedAsync();
        }

    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!await _context.Users.AnyAsync())
        {
            var users = GetInitialUsers();
            await _context.Users.AddRangeAsync(users);
        }

        if (!await _context.TodoItems.AnyAsync())
        {
            var todoItems = GetInitialTodoItems();
            await _context.TodoItems.AddRangeAsync(todoItems);
        }

        await _context.SaveChangesAsync();
    }

    private static List<User> GetInitialUsers()
    {
        List<User> users = [
            new User
            {
                UserId = Guid.NewGuid(),
                Name = "Mir Anupam Hossain Akib",
                Email = "mirakib25@gmail.com",
            }
        ];

        return users;
    }

    private static List<Todo> GetInitialTodoItems()
    {
        List<Todo> todoItems = [
            new Todo
            {
                Title = "Welcome to TodoApp!",
                Description = "This is a sample todo item which was seeded while initializing the database"
            },
            new Todo
            {
                Title = "Test Todo",
                Description = "Sample Todo application description",
                Priority = Priority.Low,
                IsUrgent = true,
            },
            new Todo
            {
                Title = "Implement Pagination for responses",
                Description = "I want to support pagination in my RESTful API. My API method should return a JSON list of product via /products/index. However, there are potentially",
                Priority = Priority.High
            }
        ];

        return todoItems;
    }
}
