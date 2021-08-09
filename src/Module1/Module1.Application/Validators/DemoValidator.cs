using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Infrastructure.Mediator;
using Module1.Application.Services;
using System;
using System.Threading.Tasks;

namespace Module1.Application.Validators
{
    public class DemoValidator<T> : IFilter<ConsumeContext<T>> where T : MmpCommand
    {
        private readonly IServiceProvider serviceProvider;

        public DemoValidator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Probe(ProbeContext context)
        {
        }

        public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dummyService = scope.ServiceProvider.GetRequiredService<IDummyService>();
                await dummyService.Validate();
            }

            //if (context.TryGetPayload(out IServiceProvider serviceProvider))
            //{
            //    this worked for resolving dependency, but filters were executed for each consumer
            //    IDummyService dummyService = serviceProvider.GetService(typeof(IDummyService)) as IDummyService;
            //    await dummyService.Validate();
            //}
            
            await next.Send(context);
        }
    }
}
