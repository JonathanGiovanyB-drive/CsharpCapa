using Capacitacion.Application.Products.SearchProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Capacitacion.Api.Controllers.Products;

[ApiController]
[Route("api/products")]
public class ProductoController : ControllerBase
{
    private readonly ISender _sender;

    public ProductoController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet("code")]
    public async Task<IActionResult> GetById(string value)
    {
        var query = new SearchProductQuery { Code = value};
        var producto = await _sender.Send(query);
        return Ok(producto);
    }
}