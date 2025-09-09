using MediatR;
using Capacitacion.Domain.Usuarios;

namespace Capacitacion.Application.Usuarios.SearchUsers;

public sealed class SearchUsuariosQuery: IRequest<Usuario>
{
    public string? Id { get; set; }
}