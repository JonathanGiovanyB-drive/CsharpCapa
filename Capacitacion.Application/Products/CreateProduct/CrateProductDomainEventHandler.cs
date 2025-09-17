using Capacitacion.Domain.Products.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Capacitacion.Application.Products.CreateProduct;


internal sealed class CreateProductDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
{
    private readonly ILogger _logger;

    public CreateProductDomainEventHandler(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<CreateProductDomainEventHandler>();
    }

    public Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"se a creado un objeto producto {notification.id}");
        return Task.CompletedTask;
    }
}

