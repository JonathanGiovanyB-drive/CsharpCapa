
using Capacitacion.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Infrastructure
{
    public sealed class CapacitacionDbContext : DbContext, IUnitOfWork
    {
        public CapacitacionDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CapacitacionDbContext).Assembly);
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var results = await base.SaveChangesAsync(cancellationToken);
            return results;
        }
    }
}
