using System.Reflection;
using DbUp;
namespace StorageMapper.Infrastructure.Persistence.DbUp;

public static class DbMigrator
{
    public static void Migrate(string connectionString)
    {
        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

        var result = upgrader.PerformUpgrade();
        if(!result.Successful)
        {
            throw new Exception("Database Migration Failed", result.Error);
        }
    }
}
