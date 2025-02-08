using Microsoft.EntityFrameworkCore;

namespace migrationbundle.persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection RegisterDatabase(
        this IServiceCollection services,
        IConfiguration configuration,
        ILogger logger)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");

        services.AddDbContext<Migrationdbcontext>(dbContextOptions =>
        {
            dbContextOptions.UseNpgsql(connectionString);
            dbContextOptions.LogTo(Console.WriteLine, LogLevel.Information);
        });

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<Migrationdbcontext>();
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
