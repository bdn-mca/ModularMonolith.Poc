using ModularMonolith.Infrastructure.EventBus;
using Module2.IntegrationEvents;
using System.Threading.Tasks;

namespace Module1.Application.EventConsumers
{
    public class ItemOrderedConsumer : EventBusHandler<ItemOrdered>
    {
        public override async Task Handle(MessageContext<ItemOrdered> message)
        {
            await Task.Delay(100);
        }
    }
}
