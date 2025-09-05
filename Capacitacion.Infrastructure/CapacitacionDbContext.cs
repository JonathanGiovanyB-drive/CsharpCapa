
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Infrastructure
{
    public sealed class CapacitacionDbContext : DbContext
    {       
        public CapacitacionDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CapacitacionDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
