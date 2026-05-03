using Domain;

namespace Infrastructure.Messaging;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<DomainEvent> domainEvents);
}
