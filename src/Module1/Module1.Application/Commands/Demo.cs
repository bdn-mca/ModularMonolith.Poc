using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using MassTransit.Registration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Infrastructure.Mediator;
using Module1.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Module1.Application.Commands
{
    public class Demo
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
            private readonly IServiceProvider serviceProvider;

            public Definition(IServiceProvider serviceProvider)
            {
                this.serviceProvider = serviceProvider;
            }

            protected override void ConfigureConsumer(
                MassTransit.IReceiveEndpointConfigurator endpointConfigurator,
                IConsumerConfigurator<Handler> consumerConfigurator)
            {
                base.ConfigureConsumer(endpointConfigurator, consumerConfigurator);

                endpointConfigurator.UseFilter(new DemoValidator<Command>(serviceProvider));

                // suggested code: https://stackoverflow.com/a/68683874/2567835
                // issue is that the filter now executes for ALL consumers, while it should only execute for the consumers
                // that have registered it (i.e. Demo and Demo2 in this example)
                //var csp = serviceProvider.GetRequiredService<IConfigurationServiceProvider>();
                //endpointConfigurator.UseConsumeFilter(typeof(DemoValidator<>), csp);
            }
        }
    }
}
