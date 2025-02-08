using Microsoft.EntityFrameworkCore;
namespace migrationbundle.persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection RegisterDatabase(
        this IServiceCollection services,
        ILogger logger)
    {
       // var connectionString = configuration.GetConnectionString("DbConnection");
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        services.AddDbContext<migrationdbcontext>(dbContextOptions =>
        {
            dbContextOptions.UseNpgsql(connectionString);
            dbContextOptions.LogTo(Console.WriteLine, LogLevel.Information);
        });

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<migrationdbcontext>();
            try
            {
                if (dbContext.Database.CanConnect())
                {
                    logger.LogInformation("Successfully connected to the database.");
                }
                else
                {
                    logger.LogWarning("Could not establish a database connection.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database connection failed.");
            }
        }

        return services;
    }
}
