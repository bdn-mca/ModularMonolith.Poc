using GreenPipes;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using ModularMonolith.Infrastructure.Mediator;
using Module1.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Module1.Application.Commands
{
    public class Demo2
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
    }
}
