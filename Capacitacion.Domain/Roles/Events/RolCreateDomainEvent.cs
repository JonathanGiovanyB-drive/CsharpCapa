using Capacitacion.Domain.Abstractions;

namespace Capacitacion.Domain.Roles.Events
{
    public sealed record RolCreateDomainEvent(Guid id) : IDomainEvent;  
}
