using System.Threading.Tasks;
using Capacitacion.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task ApplyMigration(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = services.GetRequiredService<CapacitacionDbContext>();
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "error en la migracion");

            }

        }
    }
}