

using Capacitacion.Domain.Abstractions;

namespace Capacitacion.Domain.Usuarios.Events
{
    public sealed record UsuarioCreateDomainEvent(Guid usuarioId): IDomainEvent;
}
