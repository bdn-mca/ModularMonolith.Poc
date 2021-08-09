using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Infrastructure.Mediator;
using Module1.Application.Services;
using System;
using System.Threading.Tasks;

namespace Module1.Application.Validators
{
    public class TutorialValidator<T> : IFilter<ConsumeContext<T>> where T : MmpCommand
    {
        private readonly IServiceProvider serviceProvider;

        public TutorialValidator(IServiceProvider serviceProvider)
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

            await next.Send(context);
        }
    }
}
