using MassTransit;
using System.Threading.Tasks;

namespace ModularMonolith.Infrastructure.EventBus
{
    /// <summary>
    /// Wrapper for the mass transit publisher so we don't have dependencies
    /// to third party libraries in code.
    /// </summary>
    public class EventBusDispatcher : IEventBusDispatcher
    {
        private IPublishEndpoint publishEndpoint;

        public EventBusDispatcher(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Dispatch<T>(T message) where T : class
        {
            await publishEndpoint.Publish(message);
        }
    }
}
