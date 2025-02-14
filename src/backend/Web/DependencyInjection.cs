using TodoApp.Application.Common.Interfaces;
using TodoApp.Web.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IUser, CurrentUser>();

        return services;
    }
}
