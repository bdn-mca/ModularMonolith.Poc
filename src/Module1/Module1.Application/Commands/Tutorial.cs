using GreenPipes;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using ModularMonolith.Infrastructure.Mediator;
using Module1.Application.Validators;
using System;
using System.Threading.Tasks;

namespace Module1.Application.Commands
{
    public class Tutorial
    {
        public class Command : MmpCommand
        {
            public DateTime ExecutedOn { get; set; }
        }

        public class Response
        {
            public Guid Uid { get; set; }
        }

        public class Handler : CommandHandler<Command, Response>
        {
            public override async Task<Response> Handle(Command command)
            {
                await Task.Delay(100);

                return new Response
                {
                    Uid = Guid.NewGuid()
                };
            }
        }

        public class Definition : ConsumerDefinition<Handler>
        {
            protected override void ConfigureConsumer(
                MassTransit.IReceiveEndpointConfigurator endpointConfigurator,
                IConsumerConfigurator<Handler> consumerConfigurator)
            {
                base.ConfigureConsumer(endpointConfigurator, consumerConfigurator);

                endpointConfigurator.UseFilter(new TutorialValidator<Command>());
            }
        }
    }
}
