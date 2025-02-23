using Infrastructure.Serialization;
using TodoApp.Web;
using TodoApp.Web.Common;
using static Infrastructure.Data.InitialiserExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables("API__");

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => // Add custom date time format
    {
        options.JsonSerializerOptions.Converters.Add(new CustomDateTimeOffsetConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>(); // Global exception handling middleware

await app.InitialiseDatabaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", () => $"## Welcome to TODO APP{'\n'}SERVER UP & RUNNING...");

app.MapControllers();

app.Run();
