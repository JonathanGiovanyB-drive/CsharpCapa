using Capacitacion.Domain.Abstractions;
using Capacitacion.Domain.Products;
using MediatR;

namespace Capacitacion.Application.Products.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _product;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository product, IUnitOfWork unitOfWork)
    {
        _product = product;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productNew = Product.Create(
            request.Name,
            request.Price,
            request.Description,
            null!,
            null!,
            request.CategoryId
        );

        _product.Add(productNew);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return productNew.Id;

    }
    
}
