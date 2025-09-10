using Capacitacion.Domain.Abstractions;

namespace Capacitacion.Domain.Categories.Events;

public sealed record CategoryCreatedDomainEvent(Guid categoryId): IDomainEvent;