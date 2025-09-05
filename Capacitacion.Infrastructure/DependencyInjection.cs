
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Capacitacion.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration) 
            {
            var connectionString = configuration.GetConnectionString("CapacitacionProd");

            services.AddDbContext<CapacitacionDbContext>(opt =>
                {
                    opt.LogTo(Console.WriteLine, new[]
                    {
                        DbLoggerCategory.Database.Command.Name
                    }, LogLevel.Information).EnableSensitiveDataLogging();

                    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();


                });

                return services;
            }
    }
}
