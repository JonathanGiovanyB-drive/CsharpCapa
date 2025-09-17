using Capacitacion.Domain.Products;
using Microsoft.AspNetCore.Http;

namespace Capacitacion.Application.DTOs;

public static class ProductMapper
{
    public static ProductDTO ToDTO(this Product product, HttpContext context)
    {
        return new ProductDTO(
            product.Id,
            product.Name!,
            product.Description!,
            product.Price ?? product.Price!.Value,
            $"{context.Request.Scheme}://{context.Request.Host}/Images/{product.ImageUrl}",
            product.Code!,
            product.CategoryId
        );
    }
}

public sealed record ProductDTO(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string ImageUrl,
    string Code,
    Guid CategoryId
);