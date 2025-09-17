using Capacitacion.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Capacitacion.Application.Products.AllProducts;

public sealed class AllProductQuery : IRequest<List<ProductDTO>>
{
    public HttpContext? Context { get; set; }
}