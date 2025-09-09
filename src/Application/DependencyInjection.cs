using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
    {
        return services;
    }
}
