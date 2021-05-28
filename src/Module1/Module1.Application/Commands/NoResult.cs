using ModularMonolith.Infrastructure.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Module1.Application.Commands
{
    public class NoResult
    {
        public class Command : MmpCommand
        {

        }

        public class Response
        {

        }

        public class Handler : CommandHandler<Command, Response>
        {
            public override async Task<Response> Handle(Command command)
            {
                await Task.Delay(1000);

                throw new Exception("Command handler exception");
            }
        }
    }
}
