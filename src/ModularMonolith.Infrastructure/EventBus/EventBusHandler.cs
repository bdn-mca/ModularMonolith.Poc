using MassTransit;
using System.Threading.Tasks;

namespace ModularMonolith.Infrastructure.EventBus
{
    /// <summary>
    /// Wrapper for the mass transit consumer so we don't have dependencies
    /// to third party libraries in code.
    /// </summary>
    public abstract class EventBusHandler<T> : IConsumer<T> where T : class
    {
        public async Task Consume(ConsumeContext<T> context)
        {
            await Handle(new MessageContext<T>(context.Message, context.CorrelationId?.ToString()));
        }

        public abstract Task Handle(MessageContext<T> message);
    }
}
