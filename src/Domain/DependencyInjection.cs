using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection service, IConfiguration config)
    {
        return service;
    }
}
