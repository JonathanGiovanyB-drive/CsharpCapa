using Capacitacion.Domain.Abstractions;

namespace Capacitacion.Domain.Products.Events;

public sealed record ProductCreatedDomainEvent(Guid id) : IDomainEvent;