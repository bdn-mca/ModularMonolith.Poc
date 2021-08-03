using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using ModularMonolith.Infrastructure.EventBus;
using Module1.Application.Filters;
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

    public class ItemOrderedConsumerDefinition : ConsumerDefinition<ItemOrderedConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ItemOrderedConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseFilter(new ConsoleConsumeFilter());
        }
    }
}
