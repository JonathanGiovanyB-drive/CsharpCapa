using Capacitacion.Application.DTOs;
using Capacitacion.Domain.Products;
using MediatR;

namespace Capacitacion.Application.Products.AllProducts;

internal sealed class AllProductQueryHandler : IRequestHandler<AllProductQuery, List<ProductDTO>>
{
    private readonly IProductRepository _productRepository;

    public AllProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDTO>> Handle(AllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAll(cancellationToken);
        return products.ConvertAll(x => x.ToDTO(request.Context!));         
    }
}
