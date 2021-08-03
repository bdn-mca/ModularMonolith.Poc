using ModularMonolith.Infrastructure.Mediator;
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
    }
}
