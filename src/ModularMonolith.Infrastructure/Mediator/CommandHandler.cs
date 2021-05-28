using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModularMonolith.Infrastructure.Mediator
{
    public abstract class CommandHandler<T, T1> : IConsumer<T>
        where T : MmpCommand
        where T1 : class
    {
        public async Task Consume(ConsumeContext<T> context)
        {
            var result = await Handle(context.Message);

            await context.RespondAsync(result);
        }

        public abstract Task<T1> Handle(T command);
    }
}
