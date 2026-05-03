using Contracts;
using Domain;
using Mapping;


namespace Infrastructure.Messaging;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMessageBus _messageBus;

    public DomainEventDispatcher(IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public async Task DispatchAsync(IEnumerable<DomainEvent> domainEvents)
    {
        foreach (DomainEvent domainEvent in domainEvents)
        {
            IIntegrationEvent integrationEvent = DomainEventMapper.Map(domainEvent);
            await _messageBus.PublishAsync(integrationEvent);
        }
    }
}
