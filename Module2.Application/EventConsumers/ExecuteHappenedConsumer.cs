using ModularMonolith.Infrastructure.EventBus;
using Module1.IntegrationEvents;
using System.Threading.Tasks;

namespace Module2.Application.EventConsumers
{
    public class ExecuteHappenedConsumer : EventBusHandler<ExecuteHappened>
    {
        public override async Task Handle(MessageContext<ExecuteHappened> message)
        {
            await Task.Delay(100);
        }
    }
}
