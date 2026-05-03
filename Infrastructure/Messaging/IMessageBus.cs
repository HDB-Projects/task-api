using Contracts;

namespace Infrastructure.Messaging;

public interface IMessageBus
{
    Task PublishAsync(IIntegrationEvent message);
}
