using GreenPipes;
using MassTransit;
using ModularMonolith.Infrastructure.Mediator;
using System;
using System.Threading.Tasks;

namespace Module1.Application.Validators
{
    public class DemoValidator<T> : IFilter<ConsumeContext<T>> where T : MmpCommand
    {
        public void Probe(ProbeContext context)
        {
        }

        public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
        {
            if (context.TryGetPayload(out IServiceProvider serviceProvider))
            {
                // this never executes
                // probably because this is ConsumeContext, rather than SendContext where the payload is set
            }
            
            await next.Send(context);
        }
    }
}
