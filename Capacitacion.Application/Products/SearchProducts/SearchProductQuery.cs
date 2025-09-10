
using Capacitacion.Domain.Products;
using MediatR;

namespace Capacitacion.Application.Products.SearchProducts;

public sealed class SearchProductQuery : IRequest<Product>
{
   public string? Code {get;set;}
}