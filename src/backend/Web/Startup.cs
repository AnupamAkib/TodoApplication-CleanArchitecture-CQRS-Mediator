using System.Text.Json.Serialization;

namespace TodoApp.Web;

public static class Startup
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddApplicationServices();
        services.AddWebServices();

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        return services;
    }
}
