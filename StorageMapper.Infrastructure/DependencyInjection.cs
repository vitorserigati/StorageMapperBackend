using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorageMapper.Infrastructure.Helpers;
using StorageMapper.Application.Interfaces;
using StorageMapper.Infrastructure.Providers;
using StorageMapper.Infrastructure.Persistence.DbUp;

namespace StorageMapper.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        HelperMethods.TryGetConnectionString("Default", config, out string connectionString);
        DbMigrator.Migrate(connectionString);
        services.AddSingleton<ITokenProvider, TokenProvider>();
        return services;
    }
}
