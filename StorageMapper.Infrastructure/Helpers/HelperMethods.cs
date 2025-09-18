using Microsoft.Extensions.Configuration;

namespace StorageMapper.Infrastructure.Helpers;

internal static class HelperMethods
{
    public static bool TryGetConnectionString(string key, IConfiguration config, out string connectionString)
    {
        connectionString = string.Empty;
        string connection = config.GetConnectionString(key) ?? throw new ArgumentException("Connection String not found");
        if (string.IsNullOrWhiteSpace(connection)) throw new ArgumentException("Connection String cannot be a empty string");
        connectionString = connection;
        return true;
    }
}
