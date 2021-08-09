using GreenPipes;
using MassTransit;
using ModularMonolith.Infrastructure.Mediator;
using Module1.Application.Services;
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
                IDummyService dummyService = serviceProvider.GetService(typeof(IDummyService)) as IDummyService;
                await dummyService.Validate();
            }
            
            await next.Send(context);
        }
    }
}
