
using Capacitacion.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Capacitacion.Infrastructure
{

    public sealed class CapacitacionDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        public CapacitacionDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CapacitacionDbContext).Assembly);
            base.OnModelCreating(builder);
        }

         public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var results = await base.SaveChangesAsync(cancellationToken);
            await PublishNotifications();
            return results;
        }

        private async Task PublishNotifications()
        {
            var domainEventNotifications = ChangeTracker
                .Entries<Entity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var eventNotifications = entity.GetDomainEvents();
                    entity.ClearDomainEvents();
                    return eventNotifications;
                }).ToList();

            foreach (var eventNotifications in domainEventNotifications)
            {
                await _publisher.Publish(eventNotifications);
            }
        }
    }
}
