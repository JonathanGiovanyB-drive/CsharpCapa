using System.Reflection.Metadata.Ecma335;
using Capacitacion.Application.Products.AllProducts;
using Capacitacion.Application.Products.CreateProduct;
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

    [HttpGet("code/{value}")]
    public async Task<IActionResult> GetById(string value)
    {
        HttpContext context = HttpContext;
        var query = new SearchProductQuery { Code = value, Context = context };
        var producto = await _sender.Send(query);
        return Ok(producto);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        HttpContext context = HttpContext;
        var query = new AllProductQuery { Context = context };
        var products = await _sender.Send(query);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductRequest request)
    {
        var command = new CreateProductCommand(request.Nombre, request.Descripcion, request.Precio, request.CategoryId);
        var resultado = await _sender.Send(command);

        return Ok(resultado);
    }

}