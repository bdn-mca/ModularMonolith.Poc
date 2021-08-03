using GreenPipes;
using MassTransit;
using ModularMonolith.Infrastructure.Mediator;
using System.Threading.Tasks;

namespace Module1.Application.Validators
{
    public class TutorialValidator<T> : IFilter<ConsumeContext<T>> where T : MmpCommand
    {
        public void Probe(ProbeContext context)
        {
        }

        public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
        {
            await next.Send(context);
        }
    }
}
