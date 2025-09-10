using Capacitacion.Application.Products.SearchProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Capacitacion.Api.Controllers.Products;

[ApiController]
[Route("api/productos")]
public class ProductoController : ControllerBase
{
    private readonly ISender _sender;

    public ProductoController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet("code")]
    public async Task<IActionResult> GetById(string code)
    {
        var query = new SearchProductQuery { Code = code };
        var producto = await _sender.Send(query);
        return Ok(producto);
    }
}