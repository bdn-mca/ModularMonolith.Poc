using ModularMonolith.Infrastructure.EventBus;
using Module1.IntegrationEvents;
using System.Threading.Tasks;

namespace Module1.Application.EventConsumers
{
    public class ExecuteHappenedConsumer : EventBusHandler<ExecuteHappened>
    {
        public override Task Handle(MessageContext<ExecuteHappened> message)
        {
            throw new System.Exception("Module 1 consumer failed");
        }
    }
}
