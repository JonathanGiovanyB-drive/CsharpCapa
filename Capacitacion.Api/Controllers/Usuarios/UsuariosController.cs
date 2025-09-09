using Capacitacion.Application.Usuarios.SearchUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Capacitacion.Api.Controllers.Usuarios;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly ISender _sender;

    
public UsuariosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetById(string Id)
    {
        var query = new SearchUsuariosQuery { Id = Id };
        var usuario = await _sender.Send(query);
        return Ok(usuario);
    }
}