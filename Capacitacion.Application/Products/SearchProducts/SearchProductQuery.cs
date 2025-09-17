
using Capacitacion.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Capacitacion.Application.Products.SearchProducts;

public sealed class SearchProductQuery : IRequest<ProductDTO>
{
   public string? Code { get; set; }
   public HttpContext? Context { get; set; }
   
}