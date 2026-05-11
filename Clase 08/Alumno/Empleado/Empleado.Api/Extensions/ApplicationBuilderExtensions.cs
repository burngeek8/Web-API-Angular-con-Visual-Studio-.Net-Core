using Microsoft.EntityFrameworkCore;

namespace Empleado.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task MigrationDatabaseAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = services.GetRequiredService<Infrastructure.ApplicationDbContext>();
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger("MigrationDB");
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }
}
