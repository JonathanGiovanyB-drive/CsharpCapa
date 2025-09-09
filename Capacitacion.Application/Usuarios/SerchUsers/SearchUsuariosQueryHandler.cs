using Capacitacion.Domain.Usuarios;
using MediatR;

namespace Capacitacion.Application.Usuarios.SearchUsers;

internal sealed class SearchUsuariosQueryHandler : IRequestHandler<SearchUsuariosQuery, Usuario>
{
    private readonly IUsuarioRepository _usuariosRepository;

    public SearchUsuariosQueryHandler(IUsuarioRepository usuariosRepository)
    {
        _usuariosRepository = usuariosRepository;
    }

    public async Task<Usuario> Handle(SearchUsuariosQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _usuariosRepository.GetByCode(request.Id!, cancellationToken);
        return usuario!;
    }
}