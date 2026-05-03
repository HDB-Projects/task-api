using Domain;
using Contracts;

namespace Mapping;

public class DomainEventMapper
{
    public static IIntegrationEvent Map(DomainEvent domainEvent)
    {
        return domainEvent switch
        {
            TaskCreatedDomainEvent e => new TaskCreatedEvent
            {
                Id = e.Id,
                Title = e.Title,
                CreatedAt = e.OccuredOn
            },
            _ => throw new NotImplementedException()
        };
    }
}
